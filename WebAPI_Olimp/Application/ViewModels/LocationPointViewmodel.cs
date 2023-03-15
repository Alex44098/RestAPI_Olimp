using Application.Interfaces;
using AutoMapper;
using Models.Entitis;

namespace Application.ViewModels
{
    public class LocationPointViewmodel : IMapWith<LocationPoint>
    {
        public long id { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LocationPoint, LocationPointViewmodel>()
                .ForMember(lpMv => lpMv.id,
                option => option.MapFrom(lp => lp.id))
                .ForMember(lpMv => lpMv.latitude,
                option => option.MapFrom(lp => lp.latitude))
                .ForMember(lpMv => lpMv.longitude,
                option => option.MapFrom(lp => lp.longitude));
        }
    }
}
