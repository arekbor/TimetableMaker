using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Data;
using TimetableMakerDataAccess.Dtos;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerDataAccess.Repository;

public class LineRepository : ILineRepository
{
    private readonly IConfiguration _configuration;
    public LineRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<LineModeDto> GetLineRoutesByIdAsync(int id)
    {
        const string sql = @"
        select [Lines].[id] as lineId, [lineName], [type], [model], [seats]
        from [Modes]
        inner join [Lines]
        on [Modes].[id] = [Lines].[modeId]
        where [Lines].[id] = @id;

        select [name], [zone], format([arrivalTime], N'hh\:mm\:ss') as arrivalTime
        from [Locations]
        inner join [Routes]
        on [Locations].id = [Routes].[locationId]
        where [Routes].[lineId] = @id;";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        using var multipleQuery = await dbConn.QueryMultipleAsync(sql, new { id = id});
        var resultLineModeDto = await multipleQuery.ReadFirstAsync<LineModeDto>();
        var resultRouteLocationDto = await multipleQuery.ReadAsync<RouteLocationDto>();

        resultLineModeDto.RouteLocationDto = resultRouteLocationDto.ToList();
        return resultLineModeDto;
    }

    public async Task<int> AddAsync(Line entity)
    {
        const string sql = @"
        insert into [Lines] ([lineName], [modeId])
        values (@lineName, @modeId);";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.ExecuteAsync(sql, entity);
    }

    public async Task<int> DeleteAsync(int id)
    {
        const string sql = @"
        delete from [Lines]
        where [id] = @id;";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.ExecuteAsync(sql, new { id = id});
    }

    public async Task<IReadOnlyList<Line>> GetAllAsync()
    {
        const string sql = @"
        select [id], [lineName], [modeId]
        from [Lines];";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        var result = await dbConn.QueryAsync<Line>(sql);
        return result.ToList();
    }

    public async Task<Line> GetByIdAsync(int id)
    {
        const string sql = @"
        select [id], [lineName], [modeId]
        from [Lines]
        where [id] = @id;";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.QuerySingleOrDefaultAsync<Line>(sql, new { id = id});
    }

    public async Task<int> UpdateAsync(Line entity)
    {
        const string sql = @"
        update [Lines] set
        [lineName] = IsNull(@lineName, [lineName]),
        [modeId] = IsNull(@modeId, [modeId])
        where [id] = @id";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.ExecuteAsync(sql, entity);
    }
}
