using System.ComponentModel;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class SwaggerParameterInfoAttributeFilter : IParameterFilter
{
    

    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        var type = parameter.GetType();
        var x = context;
        if(!type.IsPrimitive){
            // Nếu là 1 object => Sẽ check theo kiểu schema 
            // Filter này chỉ áp dụng để lấy description của CLASS ( vì nó lấy Context là Parameter, Cái Schema mới lấy context Class)
            var description = context.PropertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .Cast<DescriptionAttribute>()
                    .FirstOrDefault()?.Description;
                if (!string.IsNullOrEmpty(description))
                {
                    parameter.Description = description;
                }
        }
        
    }
}