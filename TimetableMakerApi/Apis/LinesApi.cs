using AutoMapper;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Dtos;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerApi.Apis;

public static class LinesApi
{
    public static void UseLinesApi(this WebApplication app)
    {
        app.MapGet("allLines", GetAllLinesAsync);
        app.MapGet("line", GetLineByIdAsync);
        app.MapGet("lineRoutes", GetLineRoutesByIdAsync);
        app.MapPost("line", AddLineAsync);
        app.MapPut("line", UpdateLineAsync);
        app.MapDelete("line", DeleteLineAsync);
    }
    private static async Task<IResult> GetLineRoutesByIdAsync(
        int id,
        ILineRepository lineRepository) {
        try
        {
            var entity = await lineRepository.GetLineRoutesByIdAsync(id);
            if (entity is null) return Results.NotFound();
            return Results.Ok(entity);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetAllLinesAsync(
        ILineRepository lineRepository) {
        try
        {
            return Results.Ok
                (await lineRepository.GetAllAsync());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetLineByIdAsync(
        int id, 
        ILineRepository lineRepository) {
        try
        {
            var entity = await lineRepository.GetByIdAsync(id);
            if(entity is null) return Results.NotFound();
            return Results.Ok(entity);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> AddLineAsync(
        LineDto lineDto,
        ILineRepository lineRepository,
        IMapper mapper) {
        try
        {
            var line = mapper.Map<Line>(lineDto);
            var rowsAffected = await lineRepository.AddAsync(line);
            if (rowsAffected > 0)
                return Results.NoContent();
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateLineAsync(
        int id,
        LineDto lineDto,
        ILineRepository lineRepository,
        IMapper mapper){
        try
        {
            var line = mapper.Map<Line>(lineDto);
            line.Id = id;
            var rowsAffected = await lineRepository.UpdateAsync(line);
            if (rowsAffected > 0)
                return Results.NoContent();
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteLineAsync(
        int id,
        ILineRepository lineRepository) {
        try
        {
            var rowsAffected = await lineRepository.DeleteAsync(id);
            if (rowsAffected > 0)
                return Results.NoContent();
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
