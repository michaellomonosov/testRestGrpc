using ProtoBuf.Grpc;
using System.ServiceModel;
using System.Threading.Tasks;

namespace RestGrpcModels
{
	[ServiceContract]
	public interface ITestGrpcService
	{
		[OperationContract]
		Task<TestReply> GetDataAsync(TestRequest request, CallContext context = default);
	}
}
