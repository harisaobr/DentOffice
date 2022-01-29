using DentOffice.Model;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using DentOffice.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Controllers
{
    public class MedicinskiKartonController : BaseCRUDController<Model.MedicinskiKarton, MedicinskiKartonSearchRequest, MedicinskiKartonUpsertRequest, MedicinskiKartonUpsertRequest>
    {
        public MedicinskiKartonController(ICRUDService<Model.MedicinskiKarton, MedicinskiKartonSearchRequest, MedicinskiKartonUpsertRequest, MedicinskiKartonUpsertRequest> service) : base(service)
        {
        }
    }
}
