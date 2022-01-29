using DentOffice.Model.Requests;
using DentOffice.WebAPI.Services;
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
    public class KorisnikController : ControllerBase
    {
        public readonly IKorisnikService _service;
        public KorisnikController(IKorisnikService service)
        {
            _service = service;
        }

        [HttpGet]
        public IList<Model.Korisnik> GetAll([FromQuery] KorisnikSearchRequest request)
        {
            return _service.GetAll(request);
        }

        [HttpGet("{id}")]
        public Model.Korisnik GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public Model.Korisnik Insert(KorisnikInsertRequest korisnici)
        {
            return _service.Insert(korisnici);
        }

        [HttpPut("{id}")]
        public Model.Korisnik Update(int id, [FromBody] KorisnikInsertRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpPut("KorisnikPacijenti/{id}")]
        public Model.Pacijent Update(int id, [FromBody] KorisniciPacijentUpdateRequest request)
        {
            return _service.Update(id, request);
        }


        [HttpGet("KorisnikPacijenti")]
        public IList<Model.KorisnikPacijent> GetAllKorisnikPacijenti([FromQuery] Model.Requests.KorisnikSearchRequest request)
        {
            return _service.GetAllKorisnikPacijenti(request);
        }


        [HttpGet("KorisnikPacijenti/{id}")]
        public Model.KorisnikPacijent GetByIdKorisnikPacijenti(int id)
        {
            return _service.GetByIdKorisnikPacijent(id);
        }
    }
}
