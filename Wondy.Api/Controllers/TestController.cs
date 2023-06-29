using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wondy.Api.Interfaces;

namespace Wondy.Api.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly ILogger<TestController> _logger;

        public TestController(IConfiguration config, IMapper mapper, IUnitOfWork unitOfWork) : base(config, mapper, unitOfWork)
        {
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}