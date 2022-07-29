using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerApi;

public static class TimetableApi
{
    public static void UseTimetableApi(this WebApplication app) {
        app.MapGet("/mode", GetModeAsync);
        app.MapPost("mode", InsertModeAsync);
    }
    private static async Task<IResult> GetModeAsync(int id, IData<Mode> modeData) {
        try
        {
            var modeDataResult = await modeData.GetAsync(id);
            if (modeDataResult is null) return Results.NotFound();
            return Results.Ok(modeDataResult);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> InsertModeAsync(Mode mode, IData<Mode> modeData) {
        try
        {
            await modeData.InsetAsync(mode);
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
