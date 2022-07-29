using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerDataAccess.Data;

//TODO map this to modeDto
public class ModeData:IData<Mode>
{
    private readonly ISqlDataAccess _sqlDataAccess;
    public ModeData(ISqlDataAccess sqlDataAccess)
    {
        _sqlDataAccess = sqlDataAccess;
    }
    public async Task<Mode> GetAsync(int id)
    {
        var resultDbContext = await _sqlDataAccess.LoadDataAsync<Mode, dynamic>
            ("dbo.spMode_Get", new { modeId = id });
        return resultDbContext.FirstOrDefault();
    }

    public async Task InsetAsync(Mode obj) => await _sqlDataAccess.SaveDataAsync
        ("dbo.spMode_Insert", new { obj.Type, obj.Model, obj.Seats });

    public async Task UpdateModeAsync(Mode obj) => await _sqlDataAccess.SaveDataAsync
        ("dbo.spMode_Update", obj);

    public async Task DeleteAsync(int id) => await _sqlDataAccess.SaveDataAsync
        ("dbo.spMode_Delete", new { modeId = id });
}
