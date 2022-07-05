using AutoMapper;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using DentOffice.WebAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public class OcjenaService : BaseCRUDService<Model.Ocjene, OcjeneSearchRequest, Database.Ocjene, OcjeneUpsertRequest, OcjeneUpsertRequest>
    {
        public OcjenaService(eDentOfficeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<Model.Ocjene> GetAll(OcjeneSearchRequest search = default)
        {
            var query = _context.Ocjenes
                .Include(i => i.Pacijent)
                .Include(i => i.Stomatolog)
                .AsQueryable();

            if (search?.PacijentId != 0)
            {
                query = query.Where(x => x.Pacijent.PacijentId == search.PacijentId);
            }
            if (search?.KorisnikId != 0)
            {
                query = query.Where(x => x.Stomatolog.KorisnikId == search.KorisnikId);
            }
            if (search?.MjesecOcjene != 0)
            {
                query = query.Where(x => x.Kreirano.Month == search.MjesecOcjene);
            }
            if (search?.GodinaOcjene != 0)
            {
                query = query.Where(x => x.Kreirano.Year == search.GodinaOcjene);
            }
            if (search?.Ocjena != 0)
            {
                query = query.Where(x => x.Ocjena == search.Ocjena);
            }
            if (search?.MjesecOcjene != 0)
            {
                query = query.Where(x => x.Kreirano.Month == search.MjesecOcjene);
            }
            if (!string.IsNullOrWhiteSpace(search?.Komentar))
            {
                query = query.Where(x => x.Komentar.ToLower().Contains(search.Komentar.ToLower()));
            }
            var entities = query.ToList();
            var result = _mapper.Map<List<Model.Ocjene>>(entities);
            return result;
        }

        public override Model.Ocjene Insert(OcjeneUpsertRequest request)
        {
            if (request.Ocjena > 5 || request.Ocjena < 0)
            {
                throw new UserException("Ocjena mora biti od 0 do 10!");
            }

            var ocjena = _context.Ocjenes.FirstOrDefault(i =>
                i.PacijentId == request.PacijentId && i.KorisnikId == request.KorisnikId);
            if (ocjena != null)
            {
                ocjena.Ocjena = request.Ocjena;
                ocjena.Komentar = request.Komentar;
            }
            else
            {
                ocjena = _mapper.Map<Database.Ocjene>(request);
                _context.Add(ocjena);
            }

            ocjena.Kreirano = DateTime.Now;
            _context.SaveChanges();

            return _mapper.Map<Model.Ocjene>(ocjena);
        }
    }
}


