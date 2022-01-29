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

    public class UlogaController : BaseCRUDController<Model.Uloga, UlogaSearchRequest, UlogaUpsertRequest, UlogaUpsertRequest>
    {
        public UlogaController(ICRUDService<Uloga, UlogaSearchRequest, UlogaUpsertRequest, UlogaUpsertRequest> service) : base(service)
        {
        }
    }
}
