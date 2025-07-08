using GrpcRestApiExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();

// This call is required to make Swashbuckle aware of gRPC endpoints
builder.Services.AddGrpcSwagger(); 

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "gRPC REST API Example", 
        Version = "v1" 
    });

    // You can now add this line back as well if you wish
    var filePath = Path.Combine(AppContext.BaseDirectory, "GrpcRestApiExample.xml");
    c.IncludeXmlComments(filePath);
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