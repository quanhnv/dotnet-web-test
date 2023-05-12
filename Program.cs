using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().
AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
})
;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Test API Full",
        Description = "Test Full Swagger feature",
    });
    options.EnableAnnotations();
    // var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));k
    options.AddSecurityDefinition("JWT Bearer", new OpenApiSecurityScheme
    {
        Description = "This is a JWT bearer authentication scheme",
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Id = "JWT Bearer A",
                    Type = ReferenceType.SecurityScheme
                }
            }, new List<string>()
        }
    });
    // Không dùng XML
    // string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // options.IncludeXmlComments(xmlPath);

    //options.OperationFilter<DisplayOperationFilter>();
    //options.ParameterFilter<SwaggerParameterInfoAttributeFilter>(); //Cho những parameter nhỏ lẻ, ko gắn với model => Lưu tên, type, rule
    options.OperationFilter<SwaggerParameterAttributeFilter>(); //Cho những parameter nhỏ lẻ, ko gắn với model => Lưu tên, type, rule
    options.SchemaFilter<SwaggerSchemaAttributeFilter>(); //Cho những parameter là những object phức tạp
    //options.Filter<SwaggerSchemaAttributeFilter>(); //Cho những parameter nhỏ lẻ, ko gắn với model => Lưu tên, type, rule
});
// builder.Services.AddApiVersioning(setup =>
//             {
//                 setup.DefaultApiVersion = new ApiVersion(1, 0);
//                 setup.AssumeDefaultVersionWhenUnspecified = true;
//                 setup.ReportApiVersions = true;
//             });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
