using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Data;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerDataAccess.Repository;

public class LocationRepository : ILocationRepository
{
    private readonly IConfiguration _configuration;
    public LocationRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<int> AddAsync(Location entity)
    {
        const string sql = @"
        insert into [Locations] ([name], [zone])
        values (@name, @zone);";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.ExecuteAsync(sql, entity);
    }

    public async Task<int> DeleteAsync(int id)
    {
        const string sql = @"
        delete from [Locations]
        where [id] = @id";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.ExecuteAsync(sql, new { id = id});
    }

    public async Task<IReadOnlyList<Location>> GetAllAsync()
    {
        const string sql = @"
        select [id], [name], [zone] 
        from [Locations]";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        var result = await dbConn.QueryAsync<Location>(sql);
        return result.ToList();
    }

    public async Task<Location> GetByIdAsync(int id)
    {
        const string sql = @"
        select [id], [name], [zone] 
        from [Locations]
        where [id] = @id";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.QuerySingleOrDefaultAsync<Location>(sql, new { id = id});
    }

    public async Task<int> UpdateAsync(Location entity)
    {
        const string sql = @"
        update [Locations] set
        [name] = IsNull(@name, [name]),
        [zone] = IsNull(@zone, [zone])
        where [id] = @id;";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.ExecuteAsync(sql, entity);
    }
}
