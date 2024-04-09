using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LiveMetal.Infrastructure.Data;
using LiveMetal.Infrastructure.Data.Models;
using LiveMetal.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        //public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        //{
        //    services.AddScoped<IHouseService, HouseService>();
        //    services.AddScoped<IAgentService, AgentService>();
        //    services.AddScoped<IStatisticService, StatisticService>();
        //    services.AddScoped<IUserService, UserService>();
        //    services.AddScoped<IRentService, RentService>();

        //    return services;
        //}

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<LiveMetalDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<LiveMetalDbContext>();

            return services;
        }
    }
}