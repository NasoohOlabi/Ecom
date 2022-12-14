using AutoMapper;
using DB.UOW;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _uow;
        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }

    /// <summary>
    /// Logger Mapper UOW controller.
    /// </summary>
    public abstract class GenericController<T> : Controller where T : class
    {
        protected readonly IUnitOfWork UOW;
        protected readonly ILogger<T> Logger;
        protected readonly IMapper Mapper; 

        public GenericController(IUnitOfWork uow, ILoggerFactory logger, IMapper mapper)
        {
            Mapper = mapper;
            Logger = logger.CreateLogger<T>();
            UOW = uow;
        }
    }
}
