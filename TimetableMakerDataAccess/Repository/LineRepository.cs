using Microsoft.Extensions.Configuration;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerDataAccess.Repository;

public class LineRepository : ILineRepository
{
    private readonly IConfiguration _configuration;
    public LineRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<int> AddAsync(Line entity)
    {
        const string sql = @"
        insert into [Lines] ([lineName], [modeId])
        values (@lineName, @modeId);";

        return await SqlDapperHelper<Line>
            .SqlExecuteAsync(sql, _configuration, entity);
    }

    public async Task<int> DeleteAsync(int id)
    {
        const string sql = @"
        delete from [Lines]
        where [id] = @id;";

        return await SqlDapperHelper<Location>
            .SqlExecuteParamsAsync(sql, _configuration, new { id = id });
    }

    public async Task<IReadOnlyList<Line>> GetAllAsync()
    {
        const string sql = @"
        select [id], [lineName], [modeId]
        from [Lines];";

        var result = await SqlDapperHelper<Line>
            .SqlQueryAsync(sql, _configuration);
        return result.ToList();
    }

    public async Task<Line> GetByIdAsync(int id)
    {
        const string sql = @"
        select [id], [lineName], [modeId]
        from [Lines]
        where [id] = @id;";

        return await SqlDapperHelper<Line>
            .SqlQuerySignleOrDefaultParamsAsync(sql, _configuration, new { id = id });
    }

    public async Task<int> UpdateAsync(Line entity)
    {
        const string sql = @"
        update [Lines] set
        [lineName] = IsNull(@lineName, [lineName]),
        [modeId] = IsNull(@modeId, [modeId])
        where [id] = @id";

        return await SqlDapperHelper<Line>
            .SqlExecuteAsync(sql, _configuration, entity);
    }
}
