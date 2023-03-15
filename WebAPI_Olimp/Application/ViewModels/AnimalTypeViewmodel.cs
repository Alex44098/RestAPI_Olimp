using Application.Interfaces;
using AutoMapper;
using Models.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class AnimalTypeViewmodel : IMapWith<AnimalType>
    {
        public long id { get; set; }
        public string type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AnimalType, AnimalTypeViewmodel>()
                .ForMember(atMv => atMv.id,
                option => option.MapFrom(at => at.id))
                .ForMember(atMv => atMv.type,
                option => option.MapFrom(at => at.type));
        }
    }
}
