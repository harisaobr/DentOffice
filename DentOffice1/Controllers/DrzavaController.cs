using AutoMapper;
using DentOffice.Model;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using DentOffice.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Controllers
{

    public class DrzavaController : BaseCRUDController<Model.Drzava, DrzavaSearchRequest, DrzavaUpsertRequest, DrzavaUpsertRequest>
    {
        public DrzavaController(ICRUDService<Model.Drzava, DrzavaSearchRequest, DrzavaUpsertRequest, DrzavaUpsertRequest> service) : base(service)
        {
        }
    }
}
