using AutoMapper;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Korisnik, Model.Korisnik>();
            CreateMap<Database.Korisnik, KorisnikInsertRequest>().ReverseMap();


            CreateMap<Database.Pacijent, Model.Pacijent>();

            CreateMap<Database.Pacijent, Model.KorisnikPacijent>();
            CreateMap<Database.Korisnik, Model.KorisnikPacijent>();

            CreateMap<Database.Korisnik, Model.Requests.KorisniciPacijentUpdateRequest>().ReverseMap();
            CreateMap<Database.Pacijent, Model.Requests.KorisniciPacijentUpdateRequest>().ReverseMap();


            CreateMap<Database.Dijagnoza, Model.Dijagnoza>();
            CreateMap<Database.Dijagnoza, DijagnozaInsertRequest>().ReverseMap();
            CreateMap<Lijek, Model.Lijek>();
            CreateMap<Database.Lijek, LijekUpsertRequest>().ReverseMap();


            CreateMap<Grad, Model.Grad>();
            CreateMap<GradUpsertRequest, Grad>().ReverseMap();
            CreateMap<Drzava, Model.Drzava>();
            CreateMap<DrzavaUpsertRequest, Drzava>().ReverseMap();
            CreateMap<MedicinskiKarton, Model.MedicinskiKarton>();
            CreateMap<MedicinskiKarton, MedicinskiKartonUpsertRequest>().ReverseMap();
            CreateMap<Usluga, UslugaUpsertRequest>().ReverseMap();
            CreateMap<Usluga, Model.Usluga>();

            CreateMap<Racun, Model.Racun>();
            CreateMap<RacunInsertRequest, Racun>();

            CreateMap<Termin, Model.Termin>();
            CreateMap<TerminInsertRequest, Termin>();


            CreateMap<Pregled, Model.Pregled>();
            CreateMap<PregledUpsertRequest, Pregled>();

            CreateMap<Uloga, Model.Uloga>();

            CreateMap<CreditCard, Model.CreditCard>();
            CreateMap<Payment, Model.Payment>();


        }
    }
}

