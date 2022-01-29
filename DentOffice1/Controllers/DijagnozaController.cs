using AutoMapper;
using DentOffice.Model;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using DentOffice.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DentOffice.WebAPI.Controllers
{
    [ApiController]
    public class DijagnozaController : BaseCRUDController<Model.Dijagnoza, DijagnozaSearchRequest, DijagnozaInsertRequest, DijagnozaInsertRequest>
    {
        public DijagnozaController(ICRUDService<Model.Dijagnoza, DijagnozaSearchRequest, DijagnozaInsertRequest, DijagnozaInsertRequest> service) : base(service)
        {
        }
    }
}
