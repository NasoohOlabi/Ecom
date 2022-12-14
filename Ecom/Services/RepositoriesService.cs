using DB.Models;
using DB.Repos;
using DB.IRepos;
using DB.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecom.Services
{
    public static class RepositoriesService
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepo, AddressRepo>();
            services.AddScoped<IAttachmentRepo, AttachmentRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<ICouponRepo, CouponRepo>();
            services.AddScoped<INotificationRepo, NotificationRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IRatingRepo, RatingRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IShippingRepo, ShippingRepo>();
            services.AddScoped<ISpecificationRepo, SpecificationRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IWishListRepo, WishListRepo>();
            return services;
        }
    }
}
