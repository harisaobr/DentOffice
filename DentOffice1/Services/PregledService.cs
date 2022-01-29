using AutoMapper;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public class PregledService : BaseCRUDService<Model.Pregled, PregledSearchRequest, Database.Pregled, PregledUpsertRequest, PregledUpsertRequest>
    {
        private readonly IKorisnikService serviceKorisnik;

        public PregledService(Database.eDentOfficeContext context, IMapper mapper, IKorisnikService serviceKorisnik) : base(context, mapper)
        {
            this.serviceKorisnik = serviceKorisnik;
        }


        public override IList<Model.Pregled> GetAll(PregledSearchRequest search = default)
        {
            var query = _context.Pregleds
                .Include(i => i.Dijagnoza)
                .Include(i => i.Termin.Usluga)
                .Include(i => i.Termin.Pacijent.Korisnik)
                .Include(i => i.Korisnik)
                .Include(i => i.Lijek)
                .AsQueryable();

            if (search?.KorisnikId != 0)
            {
                query = query.Where(x => x.Korisnik.KorisnikId == search.KorisnikId);
            }
          
            if (search?.PacijentId != 0)
            {
                query = query.Where(x => x.TerminId != null && x.Termin.PacijentId == search.PacijentId);
            }
          
            if (!string.IsNullOrWhiteSpace(search?.Napomena))
            {
                query = query.Where(x => x.Napomena.ToLower().Contains(search.Napomena.ToLower()));
            }
            var entities = query.ToList();
            var NovaLista = new List<Database.Pregled>();

            if (search.IsUplacenPregledRequest == "Ne")
            {
                foreach (var pregled in entities)
                {
                    var flag = _context.Racuns.FirstOrDefault(i => i.PregledId == pregled.PregledId && i.IsPlaceno == false);
                    if (flag != null)
                    {
                        NovaLista.Add(pregled);
                    }
                }

                var result1 = _mapper.Map<List<Model.Pregled>>(NovaLista);
                foreach (var convert in result1)
                {
                    convert.PregledIme = "Usluga: " + convert.Termin.Usluga.Naziv + "  |   Pacijent: " + convert.Termin.Pacijent.Korisnik.Ime + " " +
                                        convert.Termin.Pacijent.Korisnik.Prezime;
                }
                return result1;
            }



            var result = _mapper.Map<List<Model.Pregled>>(entities);

            foreach (var finalPregledlist in result)
            {

                finalPregledlist.DijagnozaTekst = finalPregledlist.Dijagnoza.Naziv;
                finalPregledlist.DoktorIme = finalPregledlist.Korisnik.Ime + " " + finalPregledlist.Korisnik.Prezime;
                finalPregledlist.LijekTekst = finalPregledlist.Lijek.Naziv;
                finalPregledlist.TerminRazlog = finalPregledlist.Termin.Razlog;
                finalPregledlist.TerminImePacijenta =
                    finalPregledlist.Termin.Pacijent.Korisnik.Ime + " " + finalPregledlist.Termin.Pacijent.Korisnik.Prezime;
            }

            return result;
        }

        public override Model.Pregled Insert(PregledUpsertRequest request)
        {

            var entity = _mapper.Map<Database.Pregled>(request);
            entity.KorisnikId = serviceKorisnik.GetLogiraniKorisnik().KorisnikID;
            _context.Add(entity);

            _context.SaveChanges();

            var termin = _context.Termins.Find(request.TerminId);
            var pacijent = _context.Pacijents.FirstOrDefault(i => i.PacijentId == termin.PacijentId);
            if(pacijent != null)
            {
                var medicinskiKarton = new Database.MedicinskiKarton
                {
                    Datum = DateTime.Now,
                    Napomena = entity.Napomena,
                    PacijentId = pacijent.PacijentId,
                    PregledId = entity.PregledId
                };
                _context.MedicinskiKartons.Add(medicinskiKarton);
                _context.SaveChanges();
            }

            return _mapper.Map<Model.Pregled>(entity);
        }

        public override Model.Pregled GetById(int id)
        {
            var entity = _context.Pregleds
                .Include(i => i.Korisnik)
                .Include(i => i.Termin)
                .Include(i => i.Termin.Usluga)
                .Include(i => i.Termin.Pacijent)
                .Include(i => i.Termin.Pacijent.Korisnik)
                .Include(i => i.Lijek)
                .Include(i => i.Dijagnoza).FirstOrDefault(i => i.PregledId == id);


            return _mapper.Map<Model.Pregled>(entity);
        }

        public Model.Pregled Update(int id, PregledUpsertRequest request)
        {
            var pretragaPregled = _context.Pregleds.FirstOrDefault(i => i.PregledId == id);


            _mapper.Map(request, pretragaPregled);
            _context.SaveChanges();

            var updateMedicinskiKarton = _context.MedicinskiKartons.FirstOrDefault(i => i.PregledId == id);
            if (updateMedicinskiKarton != null)
            {
                updateMedicinskiKarton.Datum = DateTime.Now;
                updateMedicinskiKarton.Napomena = pretragaPregled.Napomena;
            }
            _context.SaveChanges();

            return _mapper.Map<Model.Pregled>(pretragaPregled);
        }

    }
}
