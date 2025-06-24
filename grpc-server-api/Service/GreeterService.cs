using Grpc.Core;

namespace GrpcServer.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;

    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }

    public override Task<WeatherResponse> GetWeather(WeatherRequest request, ServerCallContext context)
    {
        var rng = new Random();
        var forecasts = Enumerable.Range(1, request.Days).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index).ToString("yyyy-MM-dd"),
            TemperatureC = rng.Next(-20, 55),
            Summary = GetSummary(rng.Next(0, 5))
        }).ToArray();

        var response = new WeatherResponse();
        response.Forecasts.AddRange(forecasts);

        return Task.FromResult(response);
    }

    private static string GetSummary(int value)
    {
        return value switch
        {
            0 => "Freezing",
            1 => "Bracing",
            2 => "Chilly",
            3 => "Cool",
            4 => "Mild",
            _ => "Warm"
        };
    }
}