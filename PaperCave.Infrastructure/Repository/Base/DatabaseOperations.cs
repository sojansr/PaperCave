using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using PaperCave.DTO.Configuration;
using Microsoft.Data.Sqlite;

namespace PaperCave.Infrastructure.Repository.Base
{
    public sealed class DatabaseOperations(IOptions<DatabaseSettings> settingsOptions) : IDatabaseOperations
    {
        private readonly DatabaseSettings _settings = settingsOptions.Value;

        public async Task<int> ExecuteAsync(string storedProc, object parameters)
        {
            using var connection = new SqliteConnection(_settings.ConnectionString);
            return await connection.ExecuteAsync(storedProc, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string storedProc, object parameters)
        {
            using var connection = new SqliteConnection(_settings.ConnectionString);
            return await connection.QueryAsync<T>(storedProc, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> QuerySingleAsync<T>(string storedProc, object parameters)
        {
            using var connection = new SqliteConnection(_settings.ConnectionString);
            return await connection.QuerySingleAsync<T>(storedProc, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
