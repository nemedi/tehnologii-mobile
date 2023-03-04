using SQLite;
using System;

namespace CoinsCatalog.Data
{
    public class DatabaseRepository : IRepository
    {
        const string name = "CoinCatalog.db";

        SQLiteAsyncConnection connection;

        private async Task Initialize()
        {
            if (connection is null)
            {
                var path = Path.Combine(FileSystem.AppDataDirectory, name);
                var flags = SQLite.SQLiteOpenFlags.ReadWrite
                    | SQLite.SQLiteOpenFlags.Create
                    | SQLite.SQLiteOpenFlags.SharedCache;
                connection = new SQLiteAsyncConnection(path, flags);
                await connection.CreateTableAsync<Models.Coin>();
            }
        }

        public async Task SaveCoinsAsync(IEnumerable<Models.Coin> coins)
        {
            await Initialize();
            await connection.DeleteAllAsync<Models.Coin>();
            await connection.InsertAllAsync(coins);
        }

        public async Task<List<Models.Issuer>> GetIssuersAsync()
        {
            await Initialize();
            return await connection.QueryAsync<Models.Issuer>("select distinct [Issuer] as [Name] from [Coin] order by [Issuer]");
        }

        public async Task<List<Models.Coin>> GetCoinsByIssuerAsync(Models.Issuer issuer)
        {
            await Initialize();
            return await connection.Table<Models.Coin>()
                .Where(coin => coin.Issuer == issuer.Name)
                .OrderBy(coin => coin.Issue)
                .ToListAsync();
        }
    }
}
