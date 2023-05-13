using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().
AddJsonOptions(options =>
{
    //options.JsonSerializerOptions.PropertyNamingPolicy = null;
})
;
builder.Services.AddSwaggerMiddleware(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerMiddleware(builder.Configuration);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
