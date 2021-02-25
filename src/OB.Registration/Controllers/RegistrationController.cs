using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OB.Data;
using System;
using System.Collections.Generic;

namespace OB.Registration.Controllers
{
    [Route("api")]
    public class RegistrationController : Controller
    {
        //-----------------------------------------------------
        private IUow uow { get; }
        private readonly IMapper mapper;
        //-----------------------------------------------------
        public RegistrationController(IUow unitOfWork, IMapper mapper)
        {
            this.uow = unitOfWork;
            this.mapper = mapper;
        }

    }
}
