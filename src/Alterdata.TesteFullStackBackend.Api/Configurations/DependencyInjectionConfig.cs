using Alterdata.TesteFullstackBackend.Core.Interfaces.Repositories;
using Alterdata.TesteFullStackBackend.Application.Interfaces;
using Alterdata.TesteFullStackBackend.Data.Context;
using Alterdata.TesteFullStackBackend.Data.Implementations;
using Alterdata.TesteFullStackBackend.Service.Implementations;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Alterdata.TesteFullStackBackend.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DbMemoryContext>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerOptionsConfig>();

            return services;
        }
    }
}
