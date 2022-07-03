using DentOffice.Model;
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
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Administrator,Stomatolog,Medicinsko Osoblje")]
    [ApiController]
    public class IzvjestajController : ControllerBase
    {
        public readonly IIzvjestajService _service;

        public IzvjestajController(IIzvjestajService service)
        {
            _service = service;
        }

        [HttpGet("{stomatologId}")]
        public int GetBrojPacijenata(int stomatologId)
        {
           return  _service.GetBrojPacijenata(stomatologId);
        }

        [HttpGet("{stomatologId}")]
        public IList<IzvjestajUsluge> GetUsluge(int stomatologId)
        {
            return _service.GetIzvjestajUsluge(stomatologId);
        }
    }
}
