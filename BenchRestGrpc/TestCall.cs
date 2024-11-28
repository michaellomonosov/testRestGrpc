using BenchmarkDotNet.Attributes;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using RestGrpcModels;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BenchRestGrpc
{
	[MemoryDiagnoser]
	public class TestCall
	{
		private readonly HttpClient _httpClient = new();
		private GrpcChannel _channel;
		private ITestGrpcService _grpcClient;
		[GlobalSetup]
		public void Setup()
		{
			_channel = GrpcChannel.ForAddress("http://localhost:5002");
			_grpcClient = _channel.CreateGrpcService<ITestGrpcService>();
		}
		[Benchmark(Baseline = true)]
		public async Task RestCall()
		{
			for (var i = 0; i < 10000; i++)
			{
				_ = await _httpClient.PostAsJsonAsync("http://localhost:5001/test/add", new TestRequest { Id = 2, Name = "from client", Time = DateTime.Now });
			}
		}
		[Benchmark]
		public void GrpcCall()
		{
			for (var i = 0; i < 10000; i++)
			{
				_ = _grpcClient.GetDataAsync(new TestRequest() { Id = 4, Name = "from grpc", Time = DateTime.Now });
			}
		}

		[GlobalCleanup]
		public void Cleanup()
		{
			_channel.Dispose();
		}
	}
}
