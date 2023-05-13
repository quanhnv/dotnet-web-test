using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;
using System.Linq;
public class SwaggerSchemaAttributeFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var type = context.Type;
        var classInfo = context.Type.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .Cast<DescriptionAttribute>()
                    .FirstOrDefault()?.Description;
        if(!string.IsNullOrEmpty(classInfo)){
            schema.Description = classInfo;
        }
        if (type.IsEnum)
        {            
            schema.Description = $"Enum of {type.Name}";// Dành để mô tả cả object
        }
        else
        {
            foreach (var propertyInfo in type.GetProperties())
            {
                var description = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .Cast<DescriptionAttribute>()
                    .FirstOrDefault()?.Description;
                if (!string.IsNullOrEmpty(description))
                {
                    //Đoạn này trong pipeline nó sẽ chuyển hết Property về Lower case nên phải add Option Json trước, nếu không thì phải check lower case ở đây
                    var property = default(OpenApiSchema);
                    var check = schema.Properties.TryGetValue(propertyInfo.Name, out property);
                    if(property!=default(OpenApiSchema)){
                        property.Description = description;
                    }
                }
            }
        }
    }
}