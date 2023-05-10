public class SwaggerDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var tags = new List<OpenApiTag>
            {
                new()
                {
                    Name = "Companies",
                    Description = "Companies related interface",
                    ExternalDocs = new OpenApiExternalDocs
                    {
                        Description = "Read more",
                        Url = new Uri("https://github.com/matjazbravc")
                    }
                },
                new()
                {
                    Name = "Departments",
                    Description = "Departments related interface",
                    ExternalDocs = new OpenApiExternalDocs
                    {
                        Description = "Here are some Departments public interfaces"
                    }
                },
                new()
                {
                    Name = "Employees",
                    Description = "Employees related interface",
                    ExternalDocs = new OpenApiExternalDocs
                    {
                        Description = "Here are some Employees public interfaces"
                    }
                }
                ,
                new()
                {
                    Name = "Users",
                    Description = "Users related interface",
                    ExternalDocs = new OpenApiExternalDocs
                    {
                        Description = "Here are some Users public interfaces"
                    }
                }
            };

        // Sort in ascending order by AssemblyName
        swaggerDoc.Tags = tags.OrderBy(x => x.Name).ToList();
    }
}