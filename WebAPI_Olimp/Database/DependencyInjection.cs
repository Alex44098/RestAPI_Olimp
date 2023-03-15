using Application.Interfaces;
using Database.DbContextes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectString = configuration["DbConnection"];
            services.AddDbContext<MainDbContext>(options =>
            {
                //options.UseSqlite(connectString);
                //options.UseMySql(connectString, new MySqlServerVersion(new Version(8, 0, 25)));
                options.UseNpgsql(connectString);
            });
            services.AddScoped((Func<IServiceProvider, IMainDbContext>)(provider =>
                provider.GetService<DbContextes.MainDbContext>()));
            return services;
        }
    }
}
