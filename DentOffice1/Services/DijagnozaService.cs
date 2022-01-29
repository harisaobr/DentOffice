 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;

namespace DentOffice.WebAPI.Services
{
    public class DijagnozaService : BaseCRUDService<Model.Dijagnoza, DijagnozaSearchRequest, Database.Dijagnoza, DijagnozaInsertRequest, DijagnozaInsertRequest>
    {
        public DijagnozaService(eDentOfficeContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
