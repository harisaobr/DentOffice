using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Database
{
    partial class eDentOfficeContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>().HasData(
                new DentOffice.WebAPI.Database.Drzava() { DrzavaId = 1, Naziv = "Bosna i Hercegovina" },
                new DentOffice.WebAPI.Database.Drzava() { DrzavaId = 2, Naziv = "Hrvatska" },
                new DentOffice.WebAPI.Database.Drzava() { DrzavaId = 3, Naziv = "Srbija" },
                new DentOffice.WebAPI.Database.Drzava() { DrzavaId = 4, Naziv = "Crna Gora" });

            modelBuilder.Entity<Grad>().HasData(
                new DentOffice.WebAPI.Database.Grad() { GradId = 1, DrzavaId = 1, Naziv = "Jablanica"},
                new DentOffice.WebAPI.Database.Grad() { GradId = 2, DrzavaId = 1, Naziv = "Mostar"},
                new DentOffice.WebAPI.Database.Grad() { GradId = 3, DrzavaId = 1, Naziv = "Sarajevo"},
                new DentOffice.WebAPI.Database.Grad() { GradId = 4, DrzavaId = 1, Naziv = "Konjic"},
                new DentOffice.WebAPI.Database.Grad() { GradId = 5, DrzavaId = 1, Naziv = "Stolac"});

            modelBuilder.Entity<Uloga>().HasData(
                new DentOffice.WebAPI.Database.Uloga() { UlogaId = 1, Naziv = "Administrator", Opis = "Administracija" },
                new DentOffice.WebAPI.Database.Uloga() { UlogaId = 2, Naziv = "Stomatolog", Opis = "Stomatolog" },
                new DentOffice.WebAPI.Database.Uloga() { UlogaId = 3, Naziv = "Medicinsko Osoblje", Opis = "Medicinsko Osoblje" },
                new DentOffice.WebAPI.Database.Uloga() { UlogaId = 4, Naziv = "Pacijent", Opis = "Pacijent" });

            modelBuilder.Entity<Korisnik>().HasData(
                new DentOffice.WebAPI.Database.Korisnik()
                {
                    KorisnikId = 1,
                    UlogaId = 1,
                    GradId = 2,
                    Ime = "Harisa",
                    Prezime = "Obradovic",
                    Email = "harisa.obradovic@edu.fit.ba",
                    KorisnickoIme = "harisaobradovic",
                    LozinkaHash = "51fj6EFNklXOT2n6JbP4qBC50Zo=",
                    LozinkaSalt = "OG/4MWdlSQQWaHd9+wehfA==",
                    Jmbg = "0905998155013",
                    DatumRodjenja = new DateTime(1998, 9, 5),
                    BrojTelefona = "38762123456",
                    Adresa = "Muje Pasica 7c",
                    Spol =Spol.Žensko,
                    Slika = File.ReadAllBytes("Helpers/default.png"),
                },
                new DentOffice.WebAPI.Database.Korisnik()
                {
                    KorisnikId = 2,
                    GradId = 1,
                    UlogaId = 1,
                    Ime = "Admin",
                    Prezime = "Sistema",
                    Email = "admin.ordinacija@gmail.com",
                    KorisnickoIme = "Administrator",
                    LozinkaHash = "dPN0un+0GqlXLR0Au1MJ795SJhc=",
                    LozinkaSalt = "CfEPCI/ScIKCo53UZX/MIA==",
                    Jmbg = "0101990150000",
                    DatumRodjenja = new DateTime(1990, 1, 1),
                    BrojTelefona = "38762123789",
                    Adresa = "",
                    Spol = Spol.Žensko,
                    Slika = File.ReadAllBytes("Helpers/default.png"),
                },
                new DentOffice.WebAPI.Database.Korisnik()
                {
                    KorisnikId = 3,
                    UlogaId = 3,
                    GradId = 1,
                    Ime = "Medicinsko",
                    Prezime = "Osoblje",
                    Email = "osoblje.ordinacija@gmail.com",
                    KorisnickoIme = "MedicinskoOsoblje",
                    LozinkaHash = "2/uMWISR22lQEqk0LGGRiMH5l3k=",
                    LozinkaSalt = "lVe6oAsC7FMxZRlDKMB+Cw==",
                    Jmbg = "1205990150008",
                    DatumRodjenja = new DateTime(1992, 6, 2),
                    BrojTelefona = "38762516615",
                    Adresa = "Jablanica BB",
                    Spol = Spol.Muško,
                    Slika = File.ReadAllBytes("Helpers/default.png"),
                },
                new DentOffice.WebAPI.Database.Korisnik()
                {
                    KorisnikId = 4,
                    UlogaId = 2,
                    GradId = 1,
                    Ime = "Stomatolog",
                    Prezime = "Osoblje",
                    Email = "stomatolog.ordinacija@gmail.com",
                    KorisnickoIme = "Stomatolog",
                    LozinkaHash = "EbAIgM1peBqerunMY9/Efjdpju4=",
                    LozinkaSalt = "pMlLkvhpuQjpQ1IjPDOiQQ==",
                    Jmbg = "011199015511",
                    DatumRodjenja = new DateTime(1985, 6, 2),
                    BrojTelefona = "38762225883",
                    Adresa = "Druga Tita 7",
                    Spol = Spol.Žensko,
                    Slika = File.ReadAllBytes("Helpers/default.png"),
                },
                new DentOffice.WebAPI.Database.Korisnik()
                {
                    KorisnikId = 5,
                    GradId = 2,
                    UlogaId = 4,
                    Ime = "Pacijent",
                    Prezime = "Mobile",
                    Email = "pacijent.mobile@gmail.com",
                    KorisnickoIme = "Pacijent",
                    LozinkaHash = "qEkPhwY9P2FiDqx1Rgg26GoapxE=",
                    LozinkaSalt = "fVZy3b4Z1cvYNep/oXc7aA==",
                    Jmbg = "0806997150007",
                    DatumRodjenja = new DateTime(1998, 6, 2),
                    BrojTelefona = "38762226238",
                    Adresa = "Bulevar BB",
                    Spol = Spol.Muško,
                    Slika = File.ReadAllBytes("Helpers/default.png"),
                });

          
            modelBuilder.Entity<Pacijent>().HasData(
                new DentOffice.WebAPI.Database.Pacijent()
                {
                    PacijentId = 1,
                    KorisnikId = 5,
                    Proteza = false,
                    Terapija = true,
                    Aparatic = true,
                });

            modelBuilder.Entity<Usluga>().HasData(
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 1, Naziv = "Čišćenje zubnog kamenca", Cijena = 15 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 2, Naziv = "Zalivanje fisura", Cijena = 20 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 3, Naziv = "Uklanjanje mekih naslaga", Cijena = 20 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 4, Naziv = "Kompozitni ispuni", Cijena = 25 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 5, Naziv = "Promjena lijeka", Cijena = 15 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 6, Naziv = "Izbjeljivanje zuba", Cijena = 50 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 7, Naziv = "Vađenje zuba", Cijena = 10 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 8, Naziv = "Popravak zuba", Cijena = 25 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 9, Naziv = "Privremena krunica", Cijena = 70 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 10, Naziv = "Mobilni ortodonski aparati", Cijena = 500 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 11, Naziv = "Plombiranje", Cijena = 25 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 12, Naziv = "FRC konzervativna nadogradnja", Cijena = 350 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 13, Naziv = "Ekstripacija pulpe", Cijena = 35 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 14, Naziv = "Uklanjanje kamenca i poliranje zuba", Cijena = 30 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 15, Naziv = "Hirurško vađenje zuba", Cijena = 50 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 16, Naziv = "Apikotomija", Cijena = 35 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 17, Naziv = "Implatanti", Cijena = 400 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 18, Naziv = "Fisura", Cijena = 60 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 19, Naziv = "Flurisanje zuba", Cijena = 35 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 20, Naziv = "Postavljanje i terapija fiksnih aparata", Cijena = 250 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 21, Naziv = "Izrada monobloka", Cijena = 300 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 22, Naziv = "Izrada krunica", Cijena = 250 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 23, Naziv = "Izrada totanlnih i parcijalnih proteza", Cijena = 450 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 24, Naziv = "Reparature totalnih i parcijalnih proteza", Cijena = 100 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 25, Naziv = "Preoblikovanje zuba kompozitom", Cijena = 25 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 26, Naziv = "Izrada i terapija mobilnih aparata", Cijena = 700 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 27, Naziv = "Izrada jednokorjenih i višekorjenih", Cijena = 75 },
                new DentOffice.WebAPI.Database.Usluga() { UslugaId = 28, Naziv = "Izrada navlaka", Cijena = 300 });

            modelBuilder.Entity<Termin>().HasData(
                new DentOffice.WebAPI.Database.Termin()
                {
                    TerminId = 1,
                    PacijentId = 1,
                    DatumVrijeme = DateTime.Now.AddDays(2),
                    Razlog = "Termin 1 razlog",
                    Hitno = true,
                    Odobreno = true,
                    UslugaId = 1
                },
                new DentOffice.WebAPI.Database.Termin()
                {
                    TerminId = 2,
                    PacijentId = 1,
                    DatumVrijeme = DateTime.Now.AddDays(4),
                    Razlog = "Termin 2 razlog",
                    Hitno = false,
                    Odobreno = true,
                    UslugaId = 2
                },
                new DentOffice.WebAPI.Database.Termin()
                {
                    TerminId = 3,
                    PacijentId = 1,
                    DatumVrijeme = DateTime.Now.AddDays(5),
                    Razlog = "Termin 3 razlog",
                    Hitno = false,
                    Odobreno = false,
                    UslugaId = 3
                },
                new DentOffice.WebAPI.Database.Termin()
                {
                    TerminId = 4,
                    PacijentId = 1,
                    DatumVrijeme = DateTime.Now.AddDays(10),
                    Razlog = "Termin 4 razlog",
                    Hitno = false,
                    Odobreno = false,
                    UslugaId = 4
                });

            modelBuilder.Entity<Lijek>().HasData(
                new DentOffice.WebAPI.Database.Lijek() { LijekId = 1, Naziv = "Pencilin" },
                new DentOffice.WebAPI.Database.Lijek() { LijekId = 2, Naziv = "Brufen" },
                new DentOffice.WebAPI.Database.Lijek() { LijekId = 3, Naziv = "Fenoksim etilpencilin" },
                new DentOffice.WebAPI.Database.Lijek() { LijekId = 4, Naziv = "Eritromicin" },
                new DentOffice.WebAPI.Database.Lijek() { LijekId = 5, Naziv = "Aspirin" },
                new DentOffice.WebAPI.Database.Lijek() { LijekId = 6, Naziv = "Analgin" },
                new DentOffice.WebAPI.Database.Lijek() { LijekId = 7, Naziv = "Bacitracin" },
                new DentOffice.WebAPI.Database.Lijek() { LijekId = 8, Naziv = "Neomacin" },
                new DentOffice.WebAPI.Database.Lijek() { LijekId = 9, Naziv = "Cefalosporin" },
                new DentOffice.WebAPI.Database.Lijek() { LijekId = 10, Naziv = "Klindamicin" });

            modelBuilder.Entity<Dijagnoza>().HasData(
                new DentOffice.WebAPI.Database.Dijagnoza() { DijagnozaId = 1, Naziv = "Nekroza pulpe", Napomena ="Nema napomene"},
                new DentOffice.WebAPI.Database.Dijagnoza() { DijagnozaId = 2, Naziv = "Generacija pulpe", Napomena ="Nema napomene"},
                new DentOffice.WebAPI.Database.Dijagnoza() { DijagnozaId = 3, Naziv = "Abnormalno formiranje tvrdog tkiva pulpi", Napomena ="Nema napomene"},
                new DentOffice.WebAPI.Database.Dijagnoza() { DijagnozaId = 4, Naziv = "Apikalna cista", Napomena ="Nema napomene"},
                new DentOffice.WebAPI.Database.Dijagnoza() { DijagnozaId = 5, Naziv = "Periapikalna cista", Napomena ="Nema napomene"},
                new DentOffice.WebAPI.Database.Dijagnoza() { DijagnozaId = 6, Naziv = "Uglavljeni zubi", Napomena ="Nema napomene"},
                new DentOffice.WebAPI.Database.Dijagnoza() { DijagnozaId = 7, Naziv = "Nabijeni zubi", Napomena ="Nema napomene"},
                new DentOffice.WebAPI.Database.Dijagnoza() { DijagnozaId = 8, Naziv = "Erozija zuba", Napomena ="Nema napomene"},
                new DentOffice.WebAPI.Database.Dijagnoza() { DijagnozaId = 9, Naziv = "Toksični celulitis", Napomena ="Nema napomene"},
                new DentOffice.WebAPI.Database.Dijagnoza() { DijagnozaId = 10, Naziv = "Periodontitis", Napomena ="Nema napomene"});

            modelBuilder.Entity<Pregled>().HasData(
                new DentOffice.WebAPI.Database.Pregled()
                {
                    PregledId = 1,
                    KorisnikId = 4,
                    TerminId = 1,
                    TrajanjePregleda = 30,
                    Napomena = "Pacijent se javio sa velikim upalama oko zuba, meko tkivo i živci",
                    DijagnozaId = 1,
                    LijekId = 1
                });

            modelBuilder.Entity<MedicinskiKarton>().HasData(
                new DentOffice.WebAPI.Database.MedicinskiKarton()
                {
                    MedicinskiKartonId = 1,
                    PregledId = 1,
                    PacijentId = 1,
                    Datum = DateTime.Now,
                    Napomena = "Pacijent se javio sa velikim upalama oko zuba, meko tkivo i živci"
                });

            modelBuilder.Entity<Racun>().HasData(
                new DentOffice.WebAPI.Database.Racun()
                {
                    RacunId = 1,
                    KorisnikId = 4,
                    PregledId = 1,
                    UkupnaCijena = 36,
                    DatumIzdavanjaRacuna = DateTime.Now,
                    IsPlaceno = false
                });


        }
    }
}
