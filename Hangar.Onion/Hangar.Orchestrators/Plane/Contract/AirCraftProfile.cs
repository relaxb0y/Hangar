using AutoMapper;
using Hangar.Core.Plane;

namespace Hangar.Orchestrators.Plane.Contract
{
    public class AirCraftProfile : Profile
    {
        public AirCraftProfile()
        {
            CreateMap<Core.Plane.AirCraft, AirCraft>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StorageData, opt => opt.MapFrom(src => src.StorageData))
                .ReverseMap();
        }
    }
}