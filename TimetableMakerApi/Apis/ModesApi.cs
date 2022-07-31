using AutoMapper;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Dtos;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerApi;

public static class ModesApi
{
    public static void UseModesApi(this WebApplication app) {
        app.MapGet("modesAll", GetAllModesAsync);
        app.MapGet("mode", GetModeByIdAsync);
        app.MapPost("mode", AddModeAsync);
        app.MapPut("mode", UpdateModeAsync);
        app.MapDelete("mode", DeleteModeAsync);
    }
    private static async Task<IResult> GetAllModesAsync(
        IModeRepository modeRepository) {
        try
        {
            var entities = await modeRepository.GetAllAsync();
            return Results.Ok(entities);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetModeByIdAsync(
        int id, 
        IModeRepository modeRepository) {
        try
        {
            var entity = await modeRepository.GetByIdAsync(id);
            if (entity is null) return Results.NotFound();
            return Results.Ok(entity);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> AddModeAsync(
        ModeDto modeDto, 
        IModeRepository modeRepository, 
        IMapper mapper) {
        try
        {
            var mode = mapper.Map<Mode>(modeDto);
            var rowsAffected = await modeRepository.AddAsync(mode);
            if (rowsAffected > 0)
                return Results.NoContent();
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateModeAsync(
        int id, 
        ModeDto modeDto, 
        IModeRepository modeRepository, 
        IMapper mapper) {
        try
        {
            var mode = mapper.Map<Mode>(modeDto);
            mode.Id = id;
            var rowsAffected = await modeRepository.UpdateAsync(mode);
            if (rowsAffected > 0)
                return Results.NoContent();
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteModeAsync(
        int id, 
        IModeRepository modeRepository) {
        try
        {
            var rowsAffected = await modeRepository.DeleteAsync(id);
            if(rowsAffected > 0)
                return Results.NoContent();
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
