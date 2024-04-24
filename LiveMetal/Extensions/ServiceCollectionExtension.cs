using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LiveMetal.Infrastructure.Data;
using LiveMetal.Infrastructure.Data.Models;
using LiveMetal.Infrastructure.Data.Common;
using LiveMetal.Core.Contracts;
using LiveMetal.Core.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IConcertService, ConcertService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IBandService, BandService>();
            services.AddScoped<IVenueService, VenueService>();
            services.AddScoped<IMemberService, MemberService>();

            return services;
        }

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