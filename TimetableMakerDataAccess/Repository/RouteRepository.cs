
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Data;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerDataAccess.Repository;

public class RouteRepository : IRouteRepository
{
    private readonly IConfiguration _configuration;
    public RouteRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<int> AddAsync(RouteLines entity)
    {
        const string sql = @"
        insert into [Routes] ([lineId], [locationId], [arrivalTime])
        values (@lineId, @locationId, @arrivalTime);";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.ExecuteAsync(sql, entity);
    }

    public async Task<int> DeleteAsync(int id)
    {
        const string sql = @"
        delete from [Routes]
        where [id] = @id;";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.ExecuteAsync(sql, new { id = id});
    }

    public async Task<IReadOnlyList<RouteLines>> GetAllAsync()
    {
        const string sql = @"
        select [id], [lineId], [locationId], format([arrivalTime], N'hh\:mm\:ss') as arrivalTime
        from [Routes];";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        var result = await dbConn.QueryAsync<RouteLines>(sql);
        return result.ToList();
    }

    public async Task<RouteLines> GetByIdAsync(int id)
    {
        const string sql = @"
        select [id], [lineId], [locationId], format([arrivalTime], N'hh\:mm\:ss') as arrivalTime
        from [Routes]
        where [id] = @id";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.QuerySingleOrDefaultAsync<RouteLines>(sql, new { id = id});
    }

    public async Task<int> UpdateAsync(RouteLines entity)
    {
        const string sql = @"
        update [Routes] set
        [lineId] = IsNull(@lineId, [lineId]),
        [locationId] = IsNull(@locationId, [locationId]),
        [arrivalTime] = IsNull(@arrivalTime, [arrivalTime])
        where [id] = @id;";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.ExecuteAsync(sql, entity);
    }
}
