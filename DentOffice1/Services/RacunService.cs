using AutoMapper;
using DentOffice.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public class RacunService : BaseCRUDService<Model.Racun, RacunSearchRequest, Database.Racun,RacunInsertRequest, RacunInsertRequest>
    {
        public RacunService(Database.eDentOfficeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Racun> GetAll(RacunSearchRequest search = default)
        {
            var query = _context.Racuns
                .Include(i => i.Korisnik)
                .Include(i => i.Pregled)
                .Include(i => i.Pregled.Termin.Usluga)
                .Include(i => i.Pregled.Termin.Pacijent.Korisnik)
                .AsQueryable();

            if (search?.RacunId != 0)
            {
                query = query.Where(x => x.RacunId == search.RacunId);
            }
            if (search?.KorisnikId != 0)
            {
                query = query.Where(x => x.Korisnik.KorisnikId == search.KorisnikId);
            }
            if (search?.PacijentId != 0)
            {
                query = query.Where(x => x.Pregled.Termin.PacijentId == search.PacijentId);
            }
            if (search?.PregledId != 0)
            {
                query = query.Where(x => x.Pregled.PregledId == search.PregledId);
            }
            if (search?.DatumOd != null)
            {
                query = query.Where(x => x.DatumIzdavanjaRacuna != null && x.DatumIzdavanjaRacuna.Value.Date >= search.DatumOd.Value.Date);
            }
            if (search?.DatumDo != null)
            {
                query = query.Where(x => x.DatumIzdavanjaRacuna != null && x.DatumIzdavanjaRacuna.Value.Date <= search.DatumDo.Value.Date);
            }
            if (!string.IsNullOrWhiteSpace(search?.ImePrezime))
            {
                query = query.Where(x => (x.Pregled.Termin.Pacijent.Korisnik.Ime + " " + x.Pregled.Termin.Pacijent.Korisnik.Prezime).ToLower().Contains(search.ImePrezime.ToLower()));
            }
            if (search?.NijeUplatioRequest == true)
            {
                query = query.Where(x => x.IsPlaceno == false);
            }

            var entities = query.ToList();
            var result = _mapper.Map<List<Model.Racun>>(entities);


            return result;
        }

      
      
    }
}
