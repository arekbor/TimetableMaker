
using Microsoft.Extensions.Configuration;
using TimetableMakerDataAccess.Contracts;
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

        return await SqlDapperHelper<RouteLines>
            .SqlExecuteAsync(sql, _configuration, entity);
    }

    public async Task<int> DeleteAsync(int id)
    {
        const string sql = @"
        delete from [Routes]
        where [id] = @id;";

        return await SqlDapperHelper<RouteLines>
            .SqlExecuteParamsAsync(sql, _configuration, new { id = id });
    }

    public async Task<IReadOnlyList<RouteLines>> GetAllAsync()
    {
        const string sql = @"
        select [id], [lineId], [locationId], format([arrivalTime], N'hh\:mm\:ss') as arrivalTime
        from [Routes];";

        var result = await SqlDapperHelper<RouteLines>
            .SqlQueryAsync(sql, _configuration);
        return result.ToList();
    }

    public async Task<RouteLines> GetByIdAsync(int id)
    {
        const string sql = @"
        select [id], [lineId], [locationId], format([arrivalTime], N'hh\:mm\:ss') as arrivalTime
        from [Routes]
        where [id] = @id";

        return await SqlDapperHelper<RouteLines>
            .SqlQuerySignleOrDefaultParamsAsync(sql, _configuration, new { id = id });
    }

    public async Task<int> UpdateAsync(RouteLines entity)
    {
        const string sql = @"
        update [Routes] set
        [lineId] = IsNull(@lineId, [lineId]),
        [locationId] = IsNull(@locationId, [locationId]),
        [arrivalTime] = IsNull(@arrivalTime, [arrivalTime])
        where [id] = @id;";

        return await SqlDapperHelper<RouteLines>
            .SqlExecuteAsync(sql, _configuration, entity);
    }
}
