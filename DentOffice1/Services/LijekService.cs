using AutoMapper;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public class LijekService : BaseCRUDService<Model.Lijek, LijekSearchRequest, Database.Lijek, LijekUpsertRequest, LijekUpsertRequest>
    {
        public LijekService(eDentOfficeContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
