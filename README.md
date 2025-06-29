# gRPC Server API (.NET 8, C# 12)

This project is a simple gRPC server built with ASP.NET Core (.NET 8, C# 12). It demonstrates how to implement gRPC services, expose RESTful endpoints, and integrate Swagger for API documentation.

**Repository URL:**  
[https://github.com/iamhasibulhasan/grpc-server-api.git](https://github.com/iamhasibulhasan/grpc-server-api.git)

## Features

- **gRPC Service**: Implements a `HelloService` with methods for greeting and test replies.
- **RESTful Endpoints**: Includes a default HTTP GET endpoint at `/grpc` and supports additional controllers.
- **Swagger/OpenAPI**: Integrated for REST API documentation and testing in development environments.
- **HTTPS Support**: Configured to use HTTPS redirection for secure communication.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or another compatible IDE

## 📦 Required NuGet Packages

Make sure the following NuGet packages are installed:

```bash
dotnet add package Grpc.AspNetCore
```

## Project File Configuration

Your `.csproj` file should include the following for gRPC and proto support:
> **Note:** The `<Protobuf Include="Proto\hello.proto" GrpcServices="Server" />` line ensures C# code is generated from your proto file for the server.

## Project Structure

- `Program.cs`: Configures services, middleware, and endpoints.
- `Proto/hello.proto`: Protocol Buffers definition for gRPC services and messages.
- `Service/HelloService.cs`: Implements the gRPC service logic.
- `Controllers/`: (Optional) Add REST API controllers here.

## Program.cs Key Configuration

The following code in `Program.cs` is essential for enabling gRPC services in your ASP.NET Core application:

- `builder.Services.AddGrpc();` registers gRPC services with the dependency injection container.
- `app.MapGrpcService<HelloService>();` maps your gRPC service implementation to the request pipeline.
- `app.MapGet("/grpc", ...)` provides a simple REST endpoint to inform users that gRPC endpoints require a gRPC client.

Include this configuration in your `Program.cs` to ensure your gRPC server is properly set up.
