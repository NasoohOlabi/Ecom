using DB.Models;
using DB.UOW;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecom.Services
{
    public static class DbService
    {
        public static IServiceCollection AddDbService(this IServiceCollection services,
            IConfiguration Configuration)
        {
            services.AddDbContext<EComContext>(options =>
            {
                options
        .UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<EComContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
