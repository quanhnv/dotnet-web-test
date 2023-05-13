using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

public static class SwaggerExtensions2
{
    // public static void AddSwaggerMiddleware(this IServiceCollection services, IConfiguration configuration)
    // {
    //     services.Configure<SwaggerConfig>(configuration.GetSection(nameof(SwaggerConfig)));
    //     // Configure Swagger Options
    //     // services.AddTransient<IConfigureOptions<SwaggerUIOptions>, ConfigureSwaggerUiOptions>();
    //     // services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();

    //     // Register the Swagger generator
    //     services.AddSwaggerGen(options =>
    //     {
    //         // Enable Swagger annotations
    //         options.EnableAnnotations();

    //         // Application Controller's API document description information
    //         // options.DocumentFilter<SwaggerDocumentFilter>();
    //     });
    // }

    // public static void UseSwaggerMiddleware(this IApplicationBuilder app, IConfiguration config)
    // {
    //     var swaggerConfig = config.GetSection(nameof(SwaggerConfig)).Get<SwaggerConfig>();
    //     app.UseSwagger(options =>
    //     {
    //         options.RouteTemplate = $"{swaggerConfig.RoutePrefix}/{{documentName}}/{swaggerConfig.DocsFile}";
    //     });
    //     app.UseSwaggerUI(options =>
    //     {
    //         options.InjectStylesheet($"/{swaggerConfig.RoutePrefix}/swagger-custom-ui-styles.css");
    //         options.InjectJavascript($"/{swaggerConfig.RoutePrefix}/swagger-custom-script.js");
    //     });
    // }
}