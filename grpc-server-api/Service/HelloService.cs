using Grpc.Core;
using HelloServer;

namespace grpc_server_api.Service
{
    public class HelloService : Hello.HelloBase
    {
        private readonly ILogger<HelloService> _logger;

        public HelloService(ILogger<HelloService> logger)
        {
            _logger = logger;
        }

        // override proto method ToldHello
        public override Task<HelloMessageReply> SayHello(HelloMessageRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Received request: {Name}", request.Name);
            return Task.FromResult(new HelloMessageReply
            {
                Message = "Hello " + request.Name
            });
        }

        // override proto method SayTest
        public override Task<TestReply> SayTest(Google.Protobuf.WellKnownTypes.Empty request, ServerCallContext context)
        {
            var reply = new TestReply
            {
                Id = 1,
                Name = "Hasibul Hasan",
                Company = "Technonext"
            };
            return Task.FromResult(reply);
        }
    }
}
