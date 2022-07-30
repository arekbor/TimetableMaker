using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Data;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerDataAccess.Repository;

public class ModeRepository : IModeRepository
{
    private readonly IConfiguration _configuration;
    public ModeRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task AddAsync(Mode entity)
    {
        const string sql = @"
        insert into [Modes] ([type], [model], [seats])
        values
        (@type, @model, @seats);";

        using var dbConn = 
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        await dbConn.ExecuteAsync(sql, entity);
    }

    public async Task DeleteAsync(int id)
    {
        const string sql = @"
        delete from [Modes] 
        where [id] = @id;";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        await dbConn.ExecuteAsync(sql, new { id = id });
    }

    public async Task<IReadOnlyList<Mode>> GetAllAsync()
    {
        const string sql = @"
        select [id], [type], [model], [seats]
        from [Modes];";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        var result = await dbConn.QueryAsync<Mode>(sql);
        return result.ToList();
    }

    public async Task<Mode> GetByIdAsync(int id)
    {
        const string sql = @"
        select [id], [type], [model], [seats]
        from [Modes]
        where [id] = @id";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        return await dbConn.QuerySingleOrDefaultAsync<Mode>(sql, new { id = id});
    }

    public async Task UpdateAsync(Mode entity)
    {
        const string sql = @"
        update [Modes] set
        [type] = IsNull(@type, [type]),
        [model] = IsNull(@model, [model]),
        [seats] = IsNull(@seats, [seats])
        where [id] = @id";

        using var dbConn =
            new SqlConnection(_configuration.GetConnectionString(
                ConfigurationRepository.ConfigurationDatabase));

        await dbConn.ExecuteAsync(sql, entity);
    }
}
