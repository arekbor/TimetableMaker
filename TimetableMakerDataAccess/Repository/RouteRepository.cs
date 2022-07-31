
using Microsoft.Extensions.Configuration;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerDataAccess.Repository;

internal class RouteRepository : IRouteRepository
{
    private readonly IConfiguration _configuration;
    internal RouteRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    internal async Task<int> AddAsync(Route entity)
    {
        const string sql = @"
        insert into [Routes] ([lineId], [locationId], [arrivalTime])
        values (@lineId, @locationId, @arrivalTime);";

        return await SqlDapperHelper<Route>
            .SqlExecuteAsync(sql, _configuration, entity);
    }

    internal async Task<int> DeleteAsync(int id)
    {
        const string sql = @"
        delete from [Routes]
        where [id] = @id;";

        return await SqlDapperHelper<Route>
            .SqlExecuteParamsAsync(sql, _configuration, new { id = id });
    }

    internal async Task<IReadOnlyList<Route>> GetAllAsync()
    {
        const string sql = @"
        select [id], [lineId], [locationId], [arrivalTime]
        from [Routes];";

        var result = await SqlDapperHelper<Route>
            .SqlQueryAsync(sql, _configuration);
        return result.ToList();
    }

    internal async Task<Route> GetByIdAsync(int id)
    {
        const string sql = @"
        select [id], [lineId], [locationId], [arrivalTime] 
        from [Routes]
        where [id] = @id";

        return await SqlDapperHelper<Route>
            .SqlQuerySignleOrDefaultParamsAsync(sql, _configuration, new { id = id });
    }

    internal async Task<int> UpdateAsync(Route entity)
    {
        const string sql = @"
        update [Routes] set
        [lineId] = IsNull(@lineId, [lineId]),
        [locationId] = IsNull(@locationId, [locationId]),
        [arrivalTime] = IsNull(@arrivalTime, [arrivalTime])
        where [id] = @id;";

        return await SqlDapperHelper<Route>
            .SqlExecuteAsync(sql, _configuration, entity);
    }
}
