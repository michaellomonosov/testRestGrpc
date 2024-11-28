using System;
using System.Runtime.Serialization;

namespace RestGrpcModels;

[DataContract]
public class TestReply
{
	[DataMember(Order = 1)]
	public int Id { get; set; }
	[DataMember(Order = 2)]
	public string Name { get; set; }
	[DataMember(Order = 3)]
	public DateTime Time { get; set; }

}