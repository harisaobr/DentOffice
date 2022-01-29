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
    public class MedicinskiKartonService : BaseCRUDService<Model.MedicinskiKarton, MedicinskiKartonSearchRequest, Database.MedicinskiKarton, MedicinskiKartonUpsertRequest, MedicinskiKartonUpsertRequest>
    {
        public MedicinskiKartonService(eDentOfficeContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override List<Model.MedicinskiKarton> GetAll(MedicinskiKartonSearchRequest search = null)
        {
            var query = _context.MedicinskiKartons.Include(x => x.Pregled)
                .Include(x => x.Pregled.Lijek)
                .Include(x => x.Pregled.Termin)
                .Include(x => x.Pregled.Termin.Usluga)
                .Include(x => x.Pregled.Korisnik)
                .Include(x => x.Pregled.Dijagnoza)
                .Include(x => x.Pacijent)
                .Include(x => x.Pacijent.Korisnik).AsQueryable();

            if (search?.PregledId != 0)
            {
                query = query.Where(x => x.Pregled.PregledId == search.PregledId);
            }
            if (search?.PacijentId != 0)
            {
                query = query.Where(x => x.Pacijent.PacijentId == search.PacijentId);
            }
            
            var list = query.ToList();
            var result = _mapper.Map<List<Model.MedicinskiKarton>>(list);
            return result;
        }
    }
}

