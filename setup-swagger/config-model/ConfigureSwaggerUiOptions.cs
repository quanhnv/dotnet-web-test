using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

public class ConfigureSwaggerUiOptions : IConfigureOptions<SwaggerUIOptions>
{
    private readonly SwaggerConfig _swaggerConfig;
    private readonly IApiVersionDescriptionProvider _apiProvider;

    /// <summary>
    /// Initialises a new instance of the <see cref="ConfigureSwaggerUiOptions"/> class.
    /// </summary>
    /// <param name="apiProvider">The API provider.</param>
    /// <param name="swaggerConfig"></param>
    public ConfigureSwaggerUiOptions(IApiVersionDescriptionProvider apiProvider, IOptions<SwaggerConfig> swaggerConfig)
    {
        _apiProvider = apiProvider ?? throw new ArgumentNullException(nameof(apiProvider));
        _swaggerConfig = swaggerConfig.Value;
    }

    /// <inheritdoc />
    public void Configure(SwaggerUIOptions options)
    {
        options = options ?? throw new ArgumentNullException(nameof(options));
        options.RoutePrefix = _swaggerConfig.RoutePrefix;
        options.DocumentTitle = _swaggerConfig.Description;
        options.DocExpansion(DocExpansion.List);
        options.DefaultModelExpandDepth(0);

        // Configure Swagger JSON endpoints
        foreach (var description in _apiProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/{_swaggerConfig.RoutePrefix}/{description.GroupName}/{_swaggerConfig.DocsFile}", description.GroupName);
        }
    }
}