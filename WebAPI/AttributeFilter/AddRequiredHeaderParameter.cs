using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebAPI.AttributeFilter;

public class AddRequiredHeaderParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Token",
            Description = "Nhập token",
            In = ParameterLocation.Header,
            Schema = new OpenApiSchema { Type = "String" },
            Example = new OpenApiString("abcd123")
        });
    }
}