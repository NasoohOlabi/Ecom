using AutoMapper;
using DB.Models;
using DB.UOW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Ecom.Controllers
{
    public class Result
    {
        public string? Error { get; private set; }
        public string? Message { get; private set; }
        public Result(string message, string error)
        {
            this.Error = error;
            this.Message = message;
        }
    }
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
        protected Result RespondWith(string message,string error)
        {
            return new Result(message, error);
        }
        protected Result RespondWithMessage(string message)
        {
            return new Result(message, null);
        }
        protected Result RespondWithError(string error)
        {
            return new Result(null, error);
        }
    }
}