using System;
using BenchmarkDotNet.Running;

namespace BenchRestGrpc
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			BenchmarkRunner.Run<TestCall>();
			Console.ReadKey();
		}
	}
}
