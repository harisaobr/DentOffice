using AutoMapper;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public class UslugaService : BaseCRUDService<Model.Usluga, UslugaSearchRequest, Database.Usluga, UslugaUpsertRequest, UslugaUpsertRequest>
    {
        public UslugaService(eDentOfficeContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
