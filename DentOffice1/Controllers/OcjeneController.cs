using DentOffice.Model;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Controllers
{
    public class OcjeneController : BaseCRUDController<Model.Ocjene, OcjeneSearchRequest, OcjeneUpsertRequest, OcjeneUpsertRequest>
    {
        public OcjeneController(ICRUDService<Ocjene, OcjeneSearchRequest, OcjeneUpsertRequest, OcjeneUpsertRequest> service) : base(service)
        {
        }
    }
}
