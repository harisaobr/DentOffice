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

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Ime == search.Ime);
            }

            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                query = query.Where(x => x.Prezime == search.Prezime);
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

            var entities = query.ToList();

            var result = _mapper.Map<IList<Model.Korisnik>>(entities);


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
        public Model.Korisnik Update(int id, KorisnikInsertRequest request)
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

        public IList<Model.Pacijent> GetAllPacijenti(KorisnikSearchRequest search = default)
        {
            var query = _context.Pacijents
                .Include(i => i.Korisnik)
                .Include(i => i.Korisnik.Grad)
                .Include(i => i.Korisnik.Grad.Drzava)
                .Include(i => i.Korisnik.Uloga)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                query = query.Where(x => x.Korisnik.Ime == search.Ime);
            }

            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                query = query.Where(x => x.Korisnik.Prezime == search.Prezime);
            }

            if (!string.IsNullOrWhiteSpace(search?.Email))
            {
                query = query.Where(x => x.Korisnik.Email == search.Email);
            }

            if (!string.IsNullOrWhiteSpace(search?.JMBG))
            {
                query = query.Where(x => x.Korisnik.Jmbg == search.JMBG);
            }

            if (!string.IsNullOrWhiteSpace(search?.Grad))
            {
                query = query.Where(x => x.Korisnik.Grad.Naziv == search.Grad);
            }

            if (!string.IsNullOrWhiteSpace(search?.Drzava))
            {
                query = query.Where(x => x.Korisnik.Grad.Drzava.Naziv == search.Drzava);
            }

            var entities = query.ToList();

            var result = _mapper.Map<IList<Model.Pacijent>>(entities);


            return result;
        }

        public IList<Model.KorisnikPacijent> GetAllKorisnikPacijenti(KorisnikSearchRequest search = default)
        {
            var pacijenti = _context.Pacijents
                .Include(i => i.Korisnik.Grad)
                .Include(i => i.Korisnik.Grad.Drzava)
                .Include(i => i.Korisnik.Uloga)
                .Where(i => i.Korisnik.UlogaId == 4)
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                pacijenti = pacijenti.Where(x => x.Korisnik.Ime == search.Ime);
            }

            if (!string.IsNullOrWhiteSpace(search?.Prezime))
            {
                pacijenti = pacijenti.Where(x => x.Korisnik.Prezime == search.Prezime);
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

        public Model.KorisnikPacijent UpdateKorisniciPacijent(int id, KorisniciPacijentUpdateRequest request)
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
            if (request.Password != request.PasswordConfirm)
            {
                throw new UserException("Password i potvrda se ne slažu!");
            }

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

            return _mapper.Map<Model.KorisnikPacijent>(korisnik);
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
    }

}
