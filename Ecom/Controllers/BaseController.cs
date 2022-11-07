﻿using DB.UOW;
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
}