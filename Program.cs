using GrpcRestApiExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();

// Add a simple fallback for HTTP/1.1 requests
app.MapGet("/", () => "gRPC service is running. Use /v1/greeter/{name} for REST API calls.");

app.Run();