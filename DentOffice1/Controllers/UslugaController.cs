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

    public class UslugaController : BaseCRUDController<Model.Usluga, UslugaSearchRequest, UslugaUpsertRequest, UslugaUpsertRequest>
    {
        public UslugaController(ICRUDService<Usluga, UslugaSearchRequest, UslugaUpsertRequest, UslugaUpsertRequest> service) : base(service)
        {
        }
    }
}
