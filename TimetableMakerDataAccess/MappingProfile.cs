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
    }
}
