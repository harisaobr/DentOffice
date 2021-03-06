using AutoMapper;
using DentOffice.Model;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using DentOffice.WebAPI.Exceptions;
using DentOffice.WebAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public class KorisnikService : IKorisnikService
    {
        private readonly eDentOfficeContext _context;
        private readonly IMapper _mapper;

        public Model.Korisnik LogiraniKorisnik { get; private set; }

        public KorisnikService(eDentOfficeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Korisnik GetById(int id)
        {
            var entity = _context.Korisniks.Include(x => x.Grad).FirstOrDefault(x => x.KorisnikId == id);

            return _mapper.Map<Model.Korisnik>(entity);
        }


        public IList<Model.Korisnik> GetAll(KorisnikSearchRequest search)
        {
            var query = _context.Korisniks
                .Include(i => i.Grad)
                .Include(i => i.Grad.Drzava)
                .Include(i => i.Uloga)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.ImePrezime))
            {
                query = query.Where(x => (x.Ime + " " + x.Prezime).ToLower().Contains(search.ImePrezime.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(search?.Email))
            {
                query = query.Where(x => x.Email == search.Email);
            }

            if (!string.IsNullOrWhiteSpace(search?.JMBG))
            {
                query = query.Where(x => x.Jmbg == search.JMBG);
            }

            if (!string.IsNullOrWhiteSpace(search?.Grad))
            {
                query = query.Where(x => x.Grad.Naziv == search.Grad);
            }

            if (!string.IsNullOrWhiteSpace(search?.Drzava))
            {
                query = query.Where(x => x.Grad.Drzava.Naziv == search.Drzava);
            }

            if (search.ShowStomatologe)
            {
                query = query.Where(x => x.UlogaId == 2);
            }

            if (search.ShowUposlenike)
            {
                query = query.Where(x => x.Pacijents.Count == 0);
            }

            var entities = query.ToList();

            var result = _mapper.Map<IList<Model.Korisnik>>(entities);

            foreach (var korisnik in result)
            {
                korisnik.ObavljenoPregleda = _context.Pregleds.Count(x =>
                x.KorisnikId == korisnik.KorisnikID || // Stomatolog
                x.Termin.Pacijent.KorisnikId == korisnik.KorisnikID // Pacijent
                );

                if (search.ShowMojeOcjene && LogiraniKorisnik.Uloga.Naziv == "Pacijent")
                {
                    var ocjena = _context.Ocjenes.Where(x => x.Pacijent.KorisnikId == LogiraniKorisnik.KorisnikID && x.KorisnikId == korisnik.KorisnikID).FirstOrDefault();
                    if(ocjena != null)
                        korisnik.MojaOcjena = ocjena.Ocjena;
                }
            }


            return result;
        }
        public IList<Model.Korisnik> GetAllDatumOdDo(KorisnikSearchRequest search = default)
        {
            var korisnici = _context.Korisniks.Where(i => i.UlogaId == 4).ToList();

            var novalista = new List<Database.Korisnik>();
            foreach (var korisnik in korisnici)
            {

                novalista.Add(korisnik);

            }

            var result = _mapper.Map<IList<Model.Korisnik>>(novalista);

            return result;
        }

        public Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnik>(request);

            if (request.Password != request.PasswordConfirmation)
            {
                throw new UserException("Password i potvrda se ne slažu!");
            }

            var korisnici = _context.Korisniks.ToList();
            foreach (var korisnik in korisnici)
            {
                if (korisnik.KorisnickoIme == request.KorisnickoIme)
                    throw new UserException("Korisnicko ime koje ste unijeli je zauzeto!");
                if (korisnik.Email == request.Email)
                    throw new UserException("Email koji ste unijeli je zauzet!");
            }

            _context.Add(entity);

            entity.LozinkaSalt = PasswordHelper.GenerateSalt();
            entity.LozinkaHash = PasswordHelper.GenerateHash(entity.LozinkaSalt, request.Password);
            _context.SaveChanges();
            var temp = _context.Ulogas.FirstOrDefault(i => i.UlogaId == entity.UlogaId);
            if (temp != null && temp.Naziv == "Pacijent")
            {
                var noviPacijent = new Database.Pacijent
                {
                    Aparatic = false,
                    KorisnikId = entity.KorisnikId,
                    Proteza = false,
                    Terapija = false
                };
                _context.Pacijents.Add(noviPacijent);
                _context.SaveChanges();
            }

            return _mapper.Map<Model.Korisnik>(entity);
        }
        public Model.Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            var provjera = _context.Korisniks.FirstOrDefault(i => i.Email == request.Email && i.KorisnikId != id);
            if (provjera != null)
            {
                throw new UserException("Email se vec koristi!");
            }

            var entity = _context.Korisniks.Find(id);
            var exSlika = request.Slika;
            if (request.Slika == null)
            {
                exSlika = entity.Slika;

            }

            _mapper.Map(request, entity);
            entity.Slika = exSlika;
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordConfirmation)
                {
                    throw new UserException("Password i potvrda se ne slažu!");
                }
                entity.LozinkaSalt = PasswordHelper.GenerateSalt();
                entity.LozinkaHash = PasswordHelper.GenerateHash(entity.LozinkaSalt, request.Password);
            }

            _context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }

        public IList<Model.KorisnikPacijent> GetAllKorisnikPacijenti(KorisnikSearchRequest search = default)
        {
            var pacijenti = _context.Pacijents
                .Include(i => i.Korisnik.Grad)
                .Include(i => i.Korisnik.Grad.Drzava)
                .Include(i => i.Korisnik.Uloga)
                .Where(i => i.Korisnik.UlogaId == 4)
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(search?.ImePrezime))
            {
                pacijenti = pacijenti.Where(x => (x.Korisnik.Ime + " " + x.Korisnik.Prezime).ToLower().Contains(search.ImePrezime.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(search?.Email))
            {
                pacijenti = pacijenti.Where(x => x.Korisnik.Email == search.Email);
            }

            if (!string.IsNullOrWhiteSpace(search?.JMBG))
            {
                pacijenti = pacijenti.Where(x => x.Korisnik.Jmbg == search.JMBG);
            }

            if (!string.IsNullOrWhiteSpace(search?.Grad))
            {
                pacijenti = pacijenti.Where(x => x.Korisnik.Grad.Naziv == search.Grad);
            }

            if (!string.IsNullOrWhiteSpace(search?.Drzava))
            {
                pacijenti = pacijenti.Where(x => x.Korisnik.Grad.Drzava.Naziv == search.Drzava);
            }

            var entities = pacijenti.ToList();

            var result = _mapper.Map<IList<Model.KorisnikPacijent>>(entities);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = _mapper.Map<Database.Korisnik, Model.KorisnikPacijent>(entities[i].Korisnik, result[i]);
            }

            return result;
        }



        public Model.Pacijent Insert(KorisniciPacijentInsertRequest request)
        {
            var uloga = _context.Ulogas.First(i => i.Naziv == "Pacijent");

            var entity = _mapper.Map<Database.Korisnik>(request);

            if (request.Password != request.PasswordConfirm)
            {
                throw new UserException("Password i potvrda se ne slažu!");
            }

            var korisnici = _context.Korisniks.ToList();
            foreach (var korisnik in korisnici)
            {
                if (korisnik.KorisnickoIme == request.KorisnickoIme)
                    throw new UserException("Korisnicko ime koje ste unijeli je zauzeto!");
                if (korisnik.Email == request.Email)
                    throw new UserException("Email koji ste unijeli je zauzet!");
            }

            entity.Uloga = uloga;
            entity.LozinkaSalt = PasswordHelper.GenerateSalt();
            entity.LozinkaHash = PasswordHelper.GenerateHash(entity.LozinkaSalt, request.Password);

            _context.Korisniks.Add(entity);

            var noviPacijent = new Database.Pacijent
            {
                Aparatic = request.Aparatic,
                Korisnik = entity,
                Proteza = request.Proteza,
                Terapija = request.Terapija
            };
            _context.Pacijents.Add(noviPacijent);
            _context.SaveChanges();

            return _mapper.Map<Model.Pacijent>(noviPacijent);
        }


        public Model.Pacijent Update(int id, KorisniciPacijentUpdateRequest request)
        {
            var provjera = _context.Korisniks.FirstOrDefault(i => i.Email == request.Email && i.KorisnikId != id);
            if (provjera != null)
            {
                throw new UserException("Email se vec koristi!");
            }
            var korisnik = _context.Korisniks.Find(id);
            var pacijent = _context.Pacijents.FirstOrDefault(i => i.KorisnikId == korisnik.KorisnikId);

            var exSlika = request.Slika;
            if (request.Slika == null)
            {
                exSlika = korisnik.Slika;

            }
            _mapper.Map(request, korisnik);
            _mapper.Map(request, pacijent);
            korisnik.Slika = exSlika;


            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordConfirm)
                {
                    throw new UserException("Password i potvrda se ne slažu!");
                }
                korisnik.LozinkaSalt = PasswordHelper.GenerateSalt();
                korisnik.LozinkaHash = PasswordHelper.GenerateHash(korisnik.LozinkaSalt, request.Password);
            }

            _context.SaveChanges();

            return _mapper.Map<Model.Pacijent>(pacijent);

        }

        public Model.KorisnikPacijent GetByIdKorisnikPacijent(int id)
        {
            var entity = _context.Korisniks.Find(id);
            var specpodaci = _context.Pacijents.FirstOrDefault(i => i.KorisnikId == entity.KorisnikId);

            var result = _mapper.Map<Model.KorisnikPacijent>(specpodaci);
            result = _mapper.Map<Database.Korisnik, Model.KorisnikPacijent>(entity, result);
            _mapper.Map(specpodaci, result);
            return result;
        }


        public Model.Korisnik GetNajboljiStomatolog()
        {
            var korisnici = _context.Korisniks.Where(i => i.UlogaId == 2 || i.UlogaId == 1).ToList();
            var brojac = 0;
            var noviKorisnik = new Database.Korisnik();
            foreach (var korisnik in korisnici)
            {
                var pregledi = _context.Pregleds.Count(i => i.KorisnikId == korisnik.KorisnikId);
                if (pregledi > brojac)
                {
                    brojac = pregledi;
                    noviKorisnik = korisnik;
                }
            }
            var tempMap = _mapper.Map<Model.Korisnik>(noviKorisnik);
            tempMap.ObavljenoPregleda = brojac;
            return tempMap;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Model.Korisnik Profil()
        {
            var query = _context.Korisniks.AsQueryable();

            query = query.Include(x => x.Uloga);
            query = query.Include(x => x.Grad.Drzava);
            query = query.Include(x => x.Pacijents);

            return _mapper.Map<Model.Korisnik>(query.FirstOrDefault(x => x.KorisnikId == LogiraniKorisnik.KorisnikID));
        }

        public async Task<Model.Korisnik> Login(string username, string password)
        {
            var entity = await _context.Korisniks
                .Where(x => x.KorisnickoIme == username)
                .Include(x => x.Grad.Drzava)
                .Include(x => x.Uloga)
                .FirstOrDefaultAsync();

            if (entity != null)
            {
                if (PasswordHelper.GenerateHash(entity.LozinkaSalt, password) == entity.LozinkaHash)
                    return _mapper.Map<Model.Korisnik>(entity);
            }

            throw new UserException("Pogrešan username ili password");
        }

        public void SetLogiraniKorisnik(Model.Korisnik korisnik)
        {
            LogiraniKorisnik = korisnik;
        }

        public Model.Korisnik GetLogiraniKorisnik()
        {
            return LogiraniKorisnik;
        }

    }

}
