using AutoMapper;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public class DrzavaService : BaseCRUDService<Model.Drzava, DrzavaSearchRequest, Database.Drzava, DrzavaUpsertRequest, DrzavaUpsertRequest>
    {
        public DrzavaService(eDentOfficeContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
