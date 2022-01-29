﻿using DentOffice.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TSearch> : ControllerBase 
    {

        private readonly IService<T, TSearch> _service;
        public BaseController(IService<T, TSearch> service)
        {
            _service = service;
        }

         [HttpGet]
        public virtual IList<T> GetAll([FromQuery] TSearch request = default)
        {
            return _service.GetAll(request);
        }

        [HttpGet("{id}")]
        public T GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
