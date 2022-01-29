using AutoMapper;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public class UlogaService : BaseCRUDService<Model.Uloga, UlogaSearchRequest, Database.Uloga, UlogaUpsertRequest, UlogaUpsertRequest>
    {
        public UlogaService(eDentOfficeContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
