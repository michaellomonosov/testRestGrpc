using System;
using BenchmarkDotNet.Running;

namespace BenchRestGrpc
{
	internal class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<TestCall>();
			Console.ReadKey();
		}
	}
}
