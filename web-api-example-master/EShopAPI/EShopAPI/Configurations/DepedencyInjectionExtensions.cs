using EShopAPI.Infrastructure.Database.Models;
using EShopAPI.Infrastructure.Repositories;
using EShopAPI.Services;
using EShopAPI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EShopAPI.Configurations
{
    public static class DepedencyInjectionExtensions
    {
        public static IServiceCollection AddAllDependencies(this IServiceCollection service)
        {
            return service
                .AddInfrastructureDependencies()
                .AddApplicationDependencies();
        }

        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service)
        {
            return service
                .AddScoped<IRepository<Product>, ProductsRepository>()
                .AddScoped<IRepository<Tag>, TagsRepository>()
                .AddScoped<IProductTagRepository, ProductTagRepository>()
                .AddSingleton<ITimeService, TimeService>();
        }

        public static IServiceCollection AddApplicationDependencies(this IServiceCollection service)
        {
            return service
                .AddScoped<IProductsService, ProductsService>()
                .AddScoped<ITagsService, TagsService>()
                .AddScoped<IProductTagsService, ProductTagsService>();
        }
    }
}
