using AutoMapper;
using DB.Models;
using DB.UOW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Ecom.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        protected readonly ILogger<T> _logger;

        protected readonly IUnitOfWork _uow;

        protected readonly IMapper _mapper;
        public BaseController(ILogger<T> logger, IUnitOfWork uow, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _uow = uow;
        }
    }
}