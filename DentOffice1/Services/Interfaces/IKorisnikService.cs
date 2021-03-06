using DentOffice.Model;
using DentOffice.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public interface IKorisnikService : ICRUDService<Model.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikUpdateRequest>
    {
        Model.Pacijent Insert(KorisniciPacijentInsertRequest request);
        Model.Pacijent Update(int id, KorisniciPacijentUpdateRequest request);

        IList<Model.KorisnikPacijent> GetAllKorisnikPacijenti(KorisnikSearchRequest search = default);
        Model.KorisnikPacijent GetByIdKorisnikPacijent(int id);

        Model.Korisnik GetNajboljiStomatolog();

        Model.Korisnik Profil();
        Task<Korisnik> Login(string username, string password);

        void SetLogiraniKorisnik(Korisnik korisnik);
        Korisnik GetLogiraniKorisnik();
    }
}
