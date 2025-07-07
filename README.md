# GrpcRestApiExample

A modern .NET 9.0 gRPC service with JSON transcoding that provides both gRPC and REST API endpoints from a single service implementation.

## 🚀 Features

- **Dual Protocol Support**: Same service accessible via both gRPC and REST APIs
- **JSON Transcoding**: Automatic HTTP/JSON to gRPC conversion
- **Modern .NET 9.0**: Built with the latest .NET framework
- **Protocol Buffers**: Type-safe service definitions
- **Development Ready**: Configured for both HTTP/1.1 and HTTP/2 protocols

## 📋 Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 or VS Code
- Git

## 🛠️ Getting Started

### Clone the Repository
```bash
git clone https://github.com/jamestjat/GrpcRestApiExample.git
cd GrpcRestApiExample
```

### Build the Project
```bash
dotnet build
```

### Run the Application
```bash
dotnet run
```

The application will start and listen on:
- **HTTP**: http://localhost:5075
- **HTTPS**: https://localhost:7108

## 🌐 API Endpoints

### REST API (JSON Transcoding)
- **GET** `/v1/greeter/{name}` - Send a greeting via REST
- **GET** `/` - Health check endpoint

### gRPC API
- **Service**: `greet.Greeter`
- **Method**: `SayHello`
- **Proto**: Located in `Protos/greet.proto`

## 📝 Usage Examples

### REST API Call
```bash
# Using curl
curl http://localhost:5075/v1/greeter/World

# Using PowerShell
Invoke-WebRequest -Uri "http://localhost:5075/v1/greeter/World" -Method GET
```

### Expected Response
```json
{
  "message": "Hello World"
}
```

### gRPC Call
```protobuf
// Request
{
  "name": "World"
}

// Response
{
  "message": "Hello World"
}
```

## 🧪 Testing

The project includes comprehensive HTTP tests using httpyac:

```bash
# Run tests from the test directory
cd test
# Execute grpc_test.http in VS Code with httpyac extension
```

### Test Coverage
- ✅ REST API endpoints
- ✅ Error handling
- ✅ Performance validation
- ✅ Content validation
- ✅ Unicode support
- ✅ Custom headers

## 🏗️ Project Structure

```
GrpcRestApiExample/
├── Program.cs                 # Application entry point
├── GrpcRestApiExample.csproj  # Project configuration
├── appsettings.json           # Application settings
├── Protos/
│   ├── greet.proto           # gRPC service definition
│   └── google/api/           # Google API annotations
├── Services/
│   └── GreeterService.cs     # Service implementation
├── Properties/
│   └── launchSettings.json   # Launch configuration
└── test/
    └── grpc_test.http        # HTTP test suite
```

## ⚙️ Configuration

### Protocol Support
The application is configured to support both HTTP/1.1 and HTTP/2:

```json
{
  "Kestrel": {
    "EndpointDefaults": {
      "Protocols": "Http1AndHttp2"
    }
  }
}
```

### Package Dependencies
- **Grpc.AspNetCore**: Core gRPC support
- **Microsoft.AspNetCore.Grpc.JsonTranscoding**: JSON transcoding functionality

## 🔧 Development

### Adding New Services
1. Define your service in a `.proto` file
2. Add the proto file to the project in `GrpcRestApiExample.csproj`
3. Implement the service class inheriting from the generated base class
4. Register the service in `Program.cs`

### HTTP Annotations
Use Google API annotations in your proto files to define REST mappings:

```protobuf
rpc SayHello (HelloRequest) returns (HelloReply) {
  option (google.api.http) = {
    get: "/v1/greeter/{name}"
  };
}
```

## 🐛 Troubleshooting

### Common Issues

**HTTP/2 only endpoint error**: Make sure `appsettings.json` has `"Protocols": "Http1AndHttp2"`

**Proto file import errors**: Ensure proto files are correctly referenced with proper paths

**Port conflicts**: Check that ports 5075 and 7108 are available

## 📚 Learn More

- [gRPC in .NET](https://docs.microsoft.com/en-us/aspnet/core/grpc/)
- [JSON transcoding](https://docs.microsoft.com/en-us/aspnet/core/grpc/json-transcoding)
- [Protocol Buffers](https://developers.google.com/protocol-buffers)

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 👨‍💻 Author

**James Joseph** - [jamestjat](https://github.com/jamestjat)
