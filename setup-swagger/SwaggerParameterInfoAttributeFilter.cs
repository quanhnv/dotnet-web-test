using System.ComponentModel;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class SwaggerParameterInfoAttributeFilter : IParameterFilter
{
    

    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        var type = parameter.GetType();
        var schema = parameter.Schema.Properties;
        foreach (var item in context.GetType().GetProperties())
        {
            var a = item.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .Cast<DescriptionAttribute>()
                    .FirstOrDefault()?.Description;
            if(!string.IsNullOrEmpty(a)){
                parameter.Description = a;
            }
        }
    }
}