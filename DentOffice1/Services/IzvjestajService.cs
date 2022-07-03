using AutoMapper;
using DentOffice.Model;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Database;
using DentOffice.WebAPI.Exceptions;
using DentOffice.WebAPI.Helpers;
using DentOffice.WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public class IzvjestajService : IIzvjestajService
    {
        private readonly eDentOfficeContext _context;

        public IzvjestajService(eDentOfficeContext context)
        {
            _context = context;
        }

        public IList<IzvjestajUsluge> GetIzvjestajUsluge(int stomatologId)
        {
            return _context.Pregleds.Where(i => i.KorisnikId == stomatologId)
                .Select(x => x.Termin.Usluga)
                .ToList()
                .GroupBy(x => x.Naziv)
                .Select(x=> new IzvjestajUsluge
                {
                    BrojIzvrsenihUsluga = x.Count(),
                    NazivUsluge = x.Key
                }).ToList();
        }

        public int GetBrojPacijenata(int stomatologId)
        {
            return _context.Pregleds.Where(i => i.KorisnikId == stomatologId).GroupBy(x => x.Termin.PacijentId).Count();
        }
    }

}
