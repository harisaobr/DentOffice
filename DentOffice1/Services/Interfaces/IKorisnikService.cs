using DentOffice.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public interface IKorisnikService : ICRUDService<Model.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikInsertRequest>

    {
        //Model.Korisnik Login(KorisniciLoginRequest request);
        //Model.Korisnici LoginMobile(KorisniciLoginRequest request);
        //Model.Korisnici Registracija(KorisniciRegistracijaRequest request);
        //IList<Model.Pacijent> GetAllPacijenti(KorisniciSearchRequest search = default);


        Model.Pacijent Update(int id, KorisniciPacijentUpdateRequest request);
        IList<Model.KorisnikPacijent> GetAllKorisnikPacijenti(KorisnikSearchRequest search = default);
        Model.KorisnikPacijent GetByIdKorisnikPacijent(int id);
        Model.KorisnikPacijent UpdateKorisniciPacijent(int id, KorisniciPacijentUpdateRequest request);
        Model.Korisnik GetNajboljiStomatolog();
       // IList<Model.Korisnik> GetAllDatumOdDo(KorisniciSearchRequest search = default);


    }
}
