﻿using Microsoft.Extensions.Configuration;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerDataAccess.Repository;

public class ModeRepository : IModeRepository
{
    private readonly IConfiguration _configuration;
    public ModeRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<int> AddAsync(Mode entity)
    {
        const string sql = @"
        insert into [Modes] ([type], [model], [seats])
        values
        (@type, @model, @seats);";

        return await SqlDapperHelper<Mode>
            .SqlExecuteAsync(sql, _configuration, entity);
    }

    public async Task<int> DeleteAsync(int id)
    {
        const string sql = @"
        delete from [Modes] 
        where [id] = @id;";

        return await SqlDapperHelper<Location>
            .SqlExecuteParamsAsync(sql, _configuration, new { id = id });
    }

    public async Task<IReadOnlyList<Mode>> GetAllAsync()
    {
        const string sql = @"
        select [id], [type], [model], [seats]
        from [Modes];";

        var result = await SqlDapperHelper<Mode>
            .SqlQueryAsync(sql, _configuration);
        return result.ToList();
    }

    public async Task<Mode> GetByIdAsync(int id)
    {
        const string sql = @"
        select [id], [type], [model], [seats]
        from [Modes]
        where [id] = @id;";

        return await SqlDapperHelper<Mode>
            .SqlQuerySignleOrDefaultParamsAsync(sql, _configuration, new { id = id });
    }

    public async Task<int> UpdateAsync(Mode entity)
    {
        const string sql = @"
        update [Modes] set
        [type] = IsNull(@type, [type]),
        [model] = IsNull(@model, [model]),
        [seats] = IsNull(@seats, [seats])
        where [id] = @id;";

        return await SqlDapperHelper<Mode>
            .SqlExecuteAsync(sql, _configuration, entity);
    }
}