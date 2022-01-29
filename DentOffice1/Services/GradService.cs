using AutoMapper;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public class GradService : BaseCRUDService<Model.Grad, GradSearchRequest, Database.Grad, GradUpsertRequest, GradUpsertRequest>
    {
        public GradService(eDentOfficeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Grad> GetAll(GradSearchRequest search = null)
        {
            var query = _context.Grads.Include(x => x.Drzava).AsQueryable();

            if(search?.DrzavaId != null)
            {
                query = query.Where(x => x.Drzava.DrzavaId == search.DrzavaId);
            }
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv == search.Naziv);
            }
            query = query.OrderBy(x => x.Naziv);

            var list = query.ToList();

            return _mapper.Map<List<Model.Grad>>(list);
        }
    }
}
