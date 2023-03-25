using SQLite;

namespace Coins.Data
{
    public class Database
    {
        const string name = "Coins.db";

        SQLiteAsyncConnection connection;

        async Task InitializeAsync()
        {
            if (connection is null)
            {
                var path = Path.Combine(FileSystem.AppDataDirectory, name);
                var flags = SQLite.SQLiteOpenFlags.ReadWrite
                    | SQLite.SQLiteOpenFlags.Create
                    | SQLite.SQLiteOpenFlags.SharedCache;
                connection = new SQLiteAsyncConnection(path, flags);
                await connection.CreateTableAsync<Coin>();
            }
        }

        public async Task<IList<string>> GetCountriesAsync()
        {
            await InitializeAsync();
            return await connection.QueryScalarsAsync<string>("select distinct [Country] from [Coin] order by [Country]");
        }

        public async Task<IList<Coin>> GetCoinsByCountryAsync(string country)
        {
            await InitializeAsync();
            return await connection.Table<Coin>()
               .Where(coin => coin.Country == country)
               .OrderBy(coin => coin.Year)
               .ToListAsync();
        }

        public async Task<Coin?> GetCoinById(string id)
        {
            await InitializeAsync();
            return await connection.Table<Coin>()
                .Where(coin => coin.Id == id)
                .FirstAsync();
        }

        public async Task SaveCoinAsync(Coin coin)
        {
            await InitializeAsync();
            if (coin.New)
            {
                await connection.InsertAsync(coin);
                coin.New = false;
            }
            else
            {
                await connection.UpdateAsync(coin);
            }
            await connection.DeleteAllAsync<Coin>();
        }

        public async Task RemoveCoinAsync(Coin coin)
        {
            await connection.DeleteAsync<Coin>(coin);
        }

    }
}
