using Grpc.Core;

namespace GrpcRestApiExample.Services
{
    /// <summary>
    /// Greeter service implementation that provides personalized greeting functionality.
    /// This service is accessible via both gRPC protocol and REST API through JSON transcoding.
    /// </summary>
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        
        /// <summary>
        /// Initializes a new instance of the GreeterService.
        /// </summary>
        /// <param name="logger">Logger instance for logging service operations</param>
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Generates a personalized greeting message for the specified name.
        /// </summary>
        /// <param name="request">The greeting request containing the name to greet</param>
        /// <param name="context">The server call context</param>
        /// <returns>A greeting response with a personalized message</returns>
        /// <example>
        /// For a request with name "World", returns "Hello World"
        /// </example>
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Greeting request received for name: {Name}", request.Name);
            
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}