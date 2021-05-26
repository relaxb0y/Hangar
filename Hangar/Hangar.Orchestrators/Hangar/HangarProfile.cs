using AutoMapper;

namespace Hangar.Orchestrators.Hangar
{
    public class HangarProfile : Profile
    {
        public HangarProfile()
        {
            CreateMap<Models.Hangar.Hangar, Hangar>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));
        }
    }
}