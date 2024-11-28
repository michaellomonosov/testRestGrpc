using System;
using System.Threading.Tasks;
using ProtoBuf.Grpc;
using RestGrpcModels;

namespace testGrpcService.Services
{
	public class TestGrpcService : ITestGrpcService
	{
		public Task<TestReply> GetDataAsync(TestRequest request, CallContext context = default)
		{
			return Task.FromResult(new TestReply() { Id = 1, Name = "test", Time = DateTime.Now });
		}
	}
}
