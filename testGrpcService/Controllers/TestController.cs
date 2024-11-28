using System;
using Microsoft.AspNetCore.Mvc;
using RestGrpcModels;

namespace testGrpcService.Controllers
{
	[Route("test")]
	public class TestController : ControllerBase
	{
		[HttpGet("getData")]
		public IActionResult Index()
		{
			return Ok("test");
		}

		[HttpPost("add")]
		public TestReply Index([FromBody] TestRequest model)
		{
			return new TestReply
			{
				Id = 1,
				Name = "from rest",
				Time = DateTime.Now
			};
		}
	}
}
