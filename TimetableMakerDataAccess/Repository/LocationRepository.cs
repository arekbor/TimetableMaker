using Microsoft.Extensions.Configuration;
using TimetableMakerDataAccess.Contracts;
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

        return await SqlDapperHelper<Location>
            .SqlExecuteAsync(sql, _configuration, entity);
    }

    public async Task<int> DeleteAsync(int id)
    {
        const string sql = @"
        delete from [Locations]
        where [id] = @id";

        return await SqlDapperHelper<Location>
            .SqlExecuteParamsAsync(sql,_configuration, new { id = id });
    }

    public async Task<IReadOnlyList<Location>> GetAllAsync()
    {
        const string sql = @"
        select [id], [name], [zone] 
        from [Locations]";

        var result = await SqlDapperHelper<Location>
            .SqlQueryAsync(sql, _configuration);
        return result.ToList();
    }

    public async Task<Location> GetByIdAsync(int id)
    {
        const string sql = @"
        select [id], [name], [zone] 
        from [Locations]
        where [id] = @id";

        return await SqlDapperHelper<Location>
            .SqlQuerySignleOrDefaultParamsAsync(sql, _configuration, new { id = id });
    }

    public async Task<int> UpdateAsync(Location entity)
    {
        const string sql = @"
        update [Locations] set
        [name] = IsNull(@name, [name]),
        [zone] = IsNull(@zone, [zone])
        where [id] = @id;";

        return await SqlDapperHelper<Location>
            .SqlExecuteAsync(sql, _configuration, entity);
    }
}
