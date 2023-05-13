using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
public class SwaggerParameterAttributeFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var attributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .OfType<SwaggerParameterAttribute>();
        foreach (var attribute in attributes)
        {            
            var a = operation.Parameters.FirstOrDefault(b=>b.Name == attribute.Name);
            if(a!=null){
                a.Description = attribute.Description;
            }
        }
    }
}