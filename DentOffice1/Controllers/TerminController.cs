using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using DentOffice.WebAPI.Services;
using DentOffice.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TerminController : ControllerBase
    {
        private static ITerminService _terminService;

        public TerminController(ITerminService terminService)
        {
            _terminService = terminService;
        }

        [HttpGet]
        public IList<Model.Termin> GetAll([FromQuery] TerminSearchRequest request)
        {
            return _terminService.GetAll(request);
        }
        [HttpGet("{id}")]
        public Model.Termin GetById(int id)
        {
            return _terminService.GetById(id);
        }

        [HttpPost]
        public Model.Termin Insert(TerminInsertRequest termin)
        {
            return _terminService.Insert(termin);
        }

        [HttpPut("{id}")]
        public Model.Termin Update(int id, [FromBody] TerminInsertRequest request)
        {
            return _terminService.Update(id, request);
        }
    }
}
