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
            //if (search?.Dan != 0)
            //{
            //    query = query.Where(x => x.DatumIzdavanjaRacuna.Day == search.Dan);
            //}
            //if (search?.Mjesec != 0)
            //{
            //    query = query.Where(x => x.DatumIzdavanjaRacuna.Month == search.Mjesec);
            //}
            //if (search?.Godina != 0)
            //{
            //    query = query.Where(x => x.DatumIzdavanjaRacuna.Year == search.Godina);
            //}
            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Pregled.Termin.Pacijent.Korisnik.Ime == search.Ime);
            }
            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                query = query.Where(x => x.Pregled.Termin.Pacijent.Korisnik.Prezime == search.Prezime);
            }
            if (search?.NijeUplatioRequest == true)
            {
                query = query.Where(x => x.IsPlaceno == false);
            }

            var entities = query.ToList();
            var result = _mapper.Map<List<Model.Racun>>(entities);

            //foreach (var finalRacunlist in result)
            //{
            //    finalRacunlist.RacunDoktorIme = finalRacunlist.Korisnici.Ime + " " + finalRacunlist.Korisnici.Prezime;
            //    finalRacunlist.PregledPacijentIme = finalRacunlist.Pregled.Termin.Pacijent.Korisnici.Ime + " " +
            //                                        finalRacunlist.Pregled.Termin.Pacijent.Korisnici.Prezime;
            //    finalRacunlist.PregledUslugaNaziv = finalRacunlist.Pregled.Termin.Usluga.Naziv;
            //    finalRacunlist.PregledMaterijalNaziv = finalRacunlist.Pregled.Skladiste.Naziv;
            //    finalRacunlist.PregledMaterijalKolicina = finalRacunlist.Pregled.KolicinaOdabranogMaterijala.ToString("F");
            //}



            return result;
        }

      
      
    }
}
