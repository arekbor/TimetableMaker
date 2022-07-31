using AutoMapper;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Dtos;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerApi.Apis;

public static class LocationsApi
{
    public static void UseLocationsApi(this WebApplication app) {
        app.MapGet("locationsAll", GetAllLocationsAsync);
        app.MapGet("location", GetLocationByIdAsync);
        app.MapPost("location", AddLocationAcyns);
        app.MapPut("location", UpdateLocationAcyns); 
        app.MapDelete("location", DeleteLocationAsync); 
    }
    private static async Task<IResult> GetAllLocationsAsync(
        ILocationRepository locationRepository) {
        try
        {
            var result = await locationRepository.GetAllAsync();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetLocationByIdAsync(
        int id, 
        ILocationRepository locationRepository) {
        try
        {
            var entity = await locationRepository.GetByIdAsync(id);
            if(entity is null) return Results.NotFound();
            return Results.Ok(entity);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> AddLocationAcyns(
        LocationDto locationDto,
        ILocationRepository locationRepository, 
        IMapper mapper) {
        try
        {
            var location = mapper.Map<Location>(locationDto);
            var rowsAffected = await locationRepository.AddAsync(location);
            if (rowsAffected > 0)
                return Results.NoContent();
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateLocationAcyns(int id, 
        LocationDto locationDto, 
        ILocationRepository locationRepository, 
        IMapper mapper) {
        try
        {
            var location = mapper.Map<Location>(locationDto);
            location.Id = id;
            var rowsAffected = await locationRepository.UpdateAsync(location);
            if (rowsAffected > 0)
                return Results.NoContent();
            return Results.BadRequest();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteLocationAsync(
        int id,
        ILocationRepository locationRepository){
        try
        {
            var rowsAffected = await locationRepository.DeleteAsync(id);
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
