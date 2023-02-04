using AutoMapper;
using BigBangGame.Server.Models.Domain;

namespace BigBangGame.Server.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GameChoice, Choice>();
    }
}