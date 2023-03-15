using Application.Interfaces;
using AutoMapper;
using Models.Entitis;

namespace Application.ViewModels
{
    public class AnimalViewmodel : IMapWith<Animal>
    {
        public long id { get; set; }
        public long[] animalTypes { get; set; }
        public float weight { get; set; }
        public float lenght { get; set; }
        public float height { get; set; }
        public string gender { get; set; }
        public string lifeStatus { get; set; }
        public DateTime chippingDateTime { get; set; }
        public int chipperId { get; set; }
        public long chippingLocationId { get; set; }
        public long[] visitedLocations { get; set; }
        public DateTime? deathDateTime { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Animal, AnimalViewmodel>()
                .ForMember(aniMv => aniMv.id,
                option => option.MapFrom(ani => ani.id))
                .ForMember(aniMv => aniMv.animalTypes,
                option => option.MapFrom(ani => ani.animalTypes))
                .ForMember(aniMv => aniMv.weight,
                option => option.MapFrom(ani => ani.weight))
                .ForMember(aniMv => aniMv.lenght,
                option => option.MapFrom(ani => ani.lenght))
                .ForMember(aniMv => aniMv.height,
                option => option.MapFrom(ani => ani.height))
                .ForMember(aniMv => aniMv.gender,
                option => option.MapFrom(ani => ani.gender))
                .ForMember(aniMv => aniMv.lifeStatus,
                option => option.MapFrom(ani => ani.lifeStatus))
                .ForMember(aniMv => aniMv.chippingDateTime,
                option => option.MapFrom(ani => ani.chippingDateTime))
                .ForMember(aniMv => aniMv.chipperId,
                option => option.MapFrom(ani => ani.chipperId))
                .ForMember(aniMv => aniMv.chippingLocationId,
                option => option.MapFrom(ani => ani.chippingLocationId))
                .ForMember(aniMv => aniMv.visitedLocations,
                option => option.MapFrom(ani => ani.visitedLocations))
                .ForMember(aniMv => aniMv.deathDateTime,
                option => option.MapFrom(ani => ani.deathDateTime));
        }
    }
}
