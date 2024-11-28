using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Server;
using testGrpcService.Services;

namespace testGrpcService
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddCodeFirstGrpc(options =>
				  {
					  //options.MaxReceiveMessageSize = 8 * 1024 * 1024; // 8 MB
					  //options.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.Optimal;
				  });

			builder.Services.AddControllers();

			var app = builder.Build();
			app.MapControllers();
			// Configure the HTTP request pipeline.
			app.MapGrpcService<TestGrpcService>();
			app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

			app.Run();
		}
	}
}