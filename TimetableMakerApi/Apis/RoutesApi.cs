using AutoMapper;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Dtos;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerApi.Apis;

public static class RoutesApi
{
    public static void UseRoutesApi(this WebApplication app)
    {
        
    }
    private static async Task<IResult> GetAllRoutesAsync(
        IRouteRepository routeRepository) {
        try
        {
            return Results.Ok
                (await routeRepository.GetAllAsync());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetRouteByIdAsync(
        int id,
        IRouteRepository routeRepository) {
        try
        {
            var entity = await routeRepository.GetByIdAsync(id);
            if(entity is null) return Results.NotFound();
            return Results.Ok(entity);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> AddRouteAsync(
        RouteDto routeDto,
        IRouteRepository routeRepository,
        IMapper mapper) {
        try
        {
            var route = mapper.Map<TimetableMakerDataAccess.Models.Route>(routeDto);
            var rowsAffected = await routeRepository.AddAsync(route);
            if (rowsAffected > 0)
                return Results.NoContent();
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateRouteAsync(
        int id,
        RouteDto routeDto,
        IRouteRepository routeRepository,
        IMapper mapper){
        try
        {
            var route = mapper.Map<TimetableMakerDataAccess.Models.Route>(routeDto);
            route.Id = id;
            var rowsAffected = await routeRepository.UpdateAsync(route);
            if (rowsAffected > 0)
                return Results.NoContent();
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteRouteAsync(
        int id,
        IRouteRepository routeRepository) {
        try
        {
            var rowsAffected = await routeRepository.DeleteAsync(id);
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
