using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wondy.Api.Interfaces;

namespace Wondy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BaseApiController(IConfiguration config, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        protected IMapper Mapper { get { return _mapper; } }
    }
}