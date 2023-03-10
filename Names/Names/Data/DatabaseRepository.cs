using Names.Models;
using SQLite;
using System;

namespace Names.Data
{
    public class DatabaseRepository : IRepository
    {
        private SQLiteAsyncConnection connection;

        private async Task Initialize()
        {
            if (connection is null)
            {
                connection = new SQLiteAsyncConnection(
                    Path.Combine(FileSystem.AppDataDirectory, Utilities.Constants.DatabaseFile),
                    SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);
                await connection.CreateTableAsync<Models.Result>();
            }
        }

        public async Task<IList<Result>> GetResultsByName(string name)
        {
            await Initialize();
            return await connection.Table<Models.Result>()
                .Where(item => item.Name.ToLower() == name.ToLower())
                .OrderByDescending(item => item.Count)
                .ToListAsync();
        }

        public async Task SaveResults(IList<Result> items)
        {
            await Initialize();
            await connection.InsertAllAsync(items);
        }
    }
}
