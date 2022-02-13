using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Data.Context;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Interfaces;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Managers;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.Logic.Services;
using TMS_DotNet02_Online.Shchypakin.FitnessApp.WebApi.Helpers;

namespace TMS_DotNet02_Online.Shchypakin.FitnessApp.WebApi.Extentions
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddAutoMapper(typeof(AutomapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("TMS-DotNet02-Online.Shchypakin.FitnessApp.WebApi"));
            });
            //services.AddDbContext<DataContext>(options =>
            //    options.UseSqlServer(config.GetConnectionString("ApplicationConnection")));

            return services;
        }
    }
}
