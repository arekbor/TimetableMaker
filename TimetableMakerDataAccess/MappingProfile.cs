using AutoMapper;
using TimetableMakerDataAccess.Dtos;
using TimetableMakerDataAccess.Models;

namespace TimetableMakerDataAccess;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Mode, ModeDto>()
            .ReverseMap();

        CreateMap<Location, LocationDto>()
            .ReverseMap();

        CreateMap<Line, LineDto>()
            .ReverseMap();
    }
}
