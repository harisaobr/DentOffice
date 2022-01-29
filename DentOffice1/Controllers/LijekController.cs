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

    public class LijekController : BaseCRUDController<Lijek, LijekSearchRequest, LijekUpsertRequest, LijekUpsertRequest>
    {
        public LijekController(ICRUDService<Lijek, LijekSearchRequest, LijekUpsertRequest, LijekUpsertRequest> service) : base(service)
        {
        }
    }
}
