using Asp.Versioning.ApiExplorer;

namespace Alterdata.TesteFullStackBackend.Api.Configurations
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning()
                .AddMvc()
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            return services;
        }

        public static IApplicationBuilder UseApiConfig(
            this IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseSwaggerConfig(apiVersionDescriptionProvider);
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            return app;
        }
    }
}
