using Microsoft.Extensions.DependencyInjection;
using Application.Gets.GetAccount;
using Application.Posts;
using Application.Interfaces.IAccounts;
using Application.Interfaces.ILocationPoint;
using Application.Gets.GetLocationPoint;
using Application.Interfaces.IAnimalType;
using Application.Gets.GetAnimalType;
using Application.Interfaces.IAnimal;
using Application.Gets.GetAnimal;
using Application.Interfaces;
using Application.Authorization;
using Application.Interfaces.IVisitedLocation;
using Application.Gets.VisitedLocatiion;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICheckAuthorization, CheckAuthorization>();
            services.AddScoped<IGetAccountInformation, GetAccountInformation>();
            services.AddScoped<IRegistrationAccount, RegistrationAccount>();
            services.AddScoped<IGetLocationPoint, GetLocationPointInformation>();
            services.AddScoped<IAddLocationPoint, AddLocationPoint>();
            services.AddScoped<IGetAnimalType, GetAnimalTypeInformation>();
            services.AddScoped<IAddAnimalType, AddAnimalType>();
            services.AddScoped<IGetAnimalInformation, GetAnimalInformation>();
            services.AddScoped<IAddAnimalInformation, AddAnimalInformation>();
            services.AddScoped<IAddAnimalVisitedLocation, AddAnimalVisitedLocation>();
            services.AddScoped<IGetAnimalVisitedLocation, GetAnimalVisitedLocation>();
            return services;
        }
    }
}
