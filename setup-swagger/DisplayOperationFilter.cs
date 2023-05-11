using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class DisplayOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var actionDescriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

        if (actionDescriptor == null)
        {
            return;
        }

        var displayAttributes = actionDescriptor.MethodInfo.GetCustomAttributes(typeof(DisplayAttribute), false);

        if (displayAttributes == null || displayAttributes.Length == 0)
        {
            return;
        }

        var displayAttribute = (DisplayAttribute)displayAttributes[0];

        operation.Description = displayAttribute.GetDescription();
    }
}