using AutoMapper;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Dtos;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerApi;

public static class TimetableApi
{
    public static void UseTimetableApi(this WebApplication app) {
        app.MapGet("modeAll", GetAllModesAsync);
        app.MapGet("/mode", GetModeByIdAsync);
        app.MapPost("/mode", AddModeAsync);
        app.MapDelete("/mode", DeleteModeAsync);
    }
    private static async Task<IResult> GetAllModesAsync(IModeRepository modeRepository, IMapper mapper) {
        try
        {
            //TODO return nocontent if no results
            var modes = await modeRepository.GetAllAsync();
            return Results.Ok
                (mapper.Map<IEnumerable<ModeDto>>(modes));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetModeByIdAsync(int id, IModeRepository modeRepository) {
        try
        {
            var entity = await modeRepository.GetByIdAsync(id);
            if (entity == null) return Results.NotFound();
            return Results.Ok(entity);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> AddModeAsync(ModeDto modeDto, IModeRepository modeRepository, IMapper mapper) {
        try
        {
            //TODO return bad request if whatever happened
            var mode = mapper.Map<Mode>(modeDto);
            await modeRepository.AddAsync(mode);
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteModeAsync(int id, IModeRepository modeRepository) {
        try
        {
            //TODO return no content if no results
            await modeRepository.DeleteAsync(id);
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
