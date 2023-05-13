using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;

public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerMiddleware(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SwaggerConfig>(configuration.GetSection(nameof(SwaggerConfig)));
            var swaggerConfig = configuration.GetSection(nameof(SwaggerConfig)).Get<SwaggerConfig>();
            services.AddSwaggerGen();
            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.UseApiBehavior = false;
                opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                new HeaderApiVersionReader("x-api-version"),
                                                                new MediaTypeApiVersionReader("x-api-version"));
            });

            services.ConfigureOptions<ConfigureSwaggerOptions>();
            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app, IConfiguration configuration)
        {
            var swaggerConfig = configuration.GetSection(nameof(SwaggerConfig)).Get<SwaggerConfig>();
            var apiVersionDescriptionProvider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                    options.RoutePrefix = swaggerConfig.Title;
                }
                options.DisplayRequestDuration();
                options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
            });
            return app;
        }
    }
