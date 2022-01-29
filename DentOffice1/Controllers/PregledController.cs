using DentOffice.Model;
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

    public class PregledController : BaseCRUDController<Model.Pregled, PregledSearchRequest, PregledUpsertRequest, PregledUpsertRequest>
    {
        public PregledController(ICRUDService<Pregled, PregledSearchRequest, PregledUpsertRequest, PregledUpsertRequest> service) : base(service)
        {
        }
    }
}
