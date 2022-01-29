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

    public class GradController : BaseCRUDController<Model.Grad, GradSearchRequest, GradUpsertRequest, GradUpsertRequest>
    {
        public GradController(ICRUDService<Grad, GradSearchRequest, GradUpsertRequest, GradUpsertRequest> service) : base(service)
        {
        }
    }
}
