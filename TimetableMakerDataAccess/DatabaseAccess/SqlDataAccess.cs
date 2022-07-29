using Microsoft.Extensions.Configuration;
using TimetableMakerDataAccess.Contracts;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace TimetableMakerDataAccess.DatabaseAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _configuration;
    public SqlDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<IEnumerable<T>> LoadDataAsync<T, U>(
        string storedProcedure, U parameters, 
        string connectionId = "Default")
    {
        using var dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionId));
        return await dbConnection.QueryAsync<T>
            (storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveDataAsync<T>(
        string storedProdecure, 
        T parameters,
        string connectionId = "Default")
    {
        using var dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionId));
        await dbConnection.ExecuteAsync
            (storedProdecure, parameters, commandType: CommandType.StoredProcedure);
    }
}
