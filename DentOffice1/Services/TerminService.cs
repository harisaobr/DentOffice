using AutoMapper;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using DentOffice.WebAPI.Exceptions;
using DentOffice.WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{

    public class TerminService : ITerminService
    {
        private readonly eDentOfficeContext _context;
        private readonly IMapper _mapper;

        public TerminService(eDentOfficeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<Model.Termin> GetAll(TerminSearchRequest search = null)
        {
            var query = _context.Termins
               .Include(i => i.Pacijent.Korisnik)
               .Include(i => i.Usluga)
               .AsQueryable();

            if (!string.IsNullOrEmpty(search.Razlog))
            {
                query = query.Where(x => x.Razlog.ToLower().Contains(search.Razlog.ToLower()));
            }

            if (search?.PacijentId != 0)
            {
                query = query.Where(x => x.Pacijent.PacijentId == search.PacijentId);
            }
            if (search?.UslugaId != 0)
            {
                query = query.Where(x => x.Usluga.UslugaId == search.UslugaId);
            }

            var entities = query.ToList();

            var result = _mapper.Map<IList<Model.Termin>>(entities);


            return result;
        }

        public Model.Termin Insert(TerminInsertRequest request)
        {
            var entity = _mapper.Map<Database.Termin>(request);

            _context.Add(entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Termin>(entity);
        }

        public Model.Termin Update(int id, TerminInsertRequest request)
        {
            var entity = _context.Termins.Find(id);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Termin>(entity);
        }

        public Model.Termin GetById(int id)
        {
            var entity = _context.Termins
                .Include(i => i.Pacijent)
                .Include(i => i.Pacijent.Korisnik).Include(i => i.Usluga).FirstOrDefault(i => i.TerminId == id);

            return _mapper.Map<Model.Termin>(entity);
        }






    }

}
