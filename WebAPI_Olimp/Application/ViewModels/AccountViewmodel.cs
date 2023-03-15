/**/
using Application.Interfaces;
using AutoMapper;
using Models.Entitis;

namespace Application.ViewModels
{
    public class AccountViewmodel : IMapWith<Account>
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, AccountViewmodel>()
                .ForMember(userMv => userMv.id,
                option => option.MapFrom(user => user.id))
                .ForMember(userMv => userMv.firstName,
                option => option.MapFrom(user => user.firstName))
                .ForMember(userMv => userMv.lastName,
                option => option.MapFrom(user => user.lastName))
                .ForMember(userMv => userMv.email,
                option => option.MapFrom(user => user.email));
        }
    }
}
