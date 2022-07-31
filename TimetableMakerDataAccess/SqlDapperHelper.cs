using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TimetableMakerDataAccess.Data;

namespace TimetableMakerDataAccess;

internal static class SqlDapperHelper<T>
{
    internal static async Task<int> SqlExecuteAsync(string sql,IConfiguration configuration, T entity) {
        using var dbConn =
            new SqlConnection(configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.ExecuteAsync(sql, entity);
    }
    internal static async Task<int> SqlExecuteParamsAsync(string sql, IConfiguration configuration, object param = null)
    {
        using var dbConn =
            new SqlConnection(configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.ExecuteAsync(sql, param);
    }
    internal static async Task<IEnumerable<T>> SqlQueryAsync(string sql, IConfiguration configuration) {
        using var dbConn =
            new SqlConnection(configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.QueryAsync<T>(sql);
    }
    internal static async Task<T> SqlQuerySignleOrDefaultParamsAsync(string sql,IConfiguration configuration, object param = null) {
        using var dbConn =
            new SqlConnection(configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.QuerySingleOrDefaultAsync<T>(sql, param);
    } 
}
