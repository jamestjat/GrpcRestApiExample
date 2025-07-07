using GrpcRestApiExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();

// Add Swagger/OpenAPI support for gRPC
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "gRPC REST API Example", 
        Version = "v1",
        Description = "A gRPC service with JSON transcoding that provides both gRPC and REST API endpoints"
    });

    // Include XML comments for better documentation
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "GrpcRestApiExample.xml");
    c.IncludeXmlComments(filePath);
    c.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "gRPC REST API Example V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.MapGrpcService<GreeterService>();

// Add a simple fallback for HTTP/1.1 requests
app.MapGet("/health", () => "gRPC service is running. Visit /swagger for API documentation.");

app.Run();