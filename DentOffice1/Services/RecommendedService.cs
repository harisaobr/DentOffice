using AutoMapper;
using DentOffice.WebAPI.Database;
using DentOffice.WebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentOffice.WebAPI.Services
{
    public class RecommendedService : IRecommenderService
    {
        private readonly eDentOfficeContext _db;
        private readonly IMapper _mapper;
        private Dictionary<int, List<Ocjene>> stomatologRatings = new();

        public RecommendedService(eDentOfficeContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<Model.Korisnik> GetRecommendedStomatolog(int stomatologId)
        {
            LoadStomatologRatings(stomatologId);

            List<Database.Ocjene> ratingsOfCurrentStomatolog = _db.Ocjenes.Where(s => s.KorisnikId == stomatologId).OrderBy(s => s.PacijentId).ToList();


            List<Database.Ocjene> commonRatings1 = new();
            List<Database.Ocjene> commonRatings2 = new();

            List<Database.Korisnik> recommendedStomatolozi = new();

            foreach (var item in stomatologRatings)
            {
                foreach (var o in ratingsOfCurrentStomatolog)
                {
                    if (item.Value.Where(x => x.PacijentId == o.PacijentId).Any())
                    {
                        commonRatings1.Add(o);
                        commonRatings2.Add(item.Value.Where(x => x.PacijentId == o.PacijentId).FirstOrDefault());
                    }
                }
                double similarity = GetSimilarity(commonRatings1, commonRatings2);
                if (similarity > 0.5)
                {
                    recommendedStomatolozi.Add(_db.Korisniks.Where(s => s.KorisnikId == item.Key).FirstOrDefault());

                }
                commonRatings1.Clear();
                commonRatings2.Clear();
            }


            //if more than 5 stomatologs is recommended, take 5 with highest rating
            if (recommendedStomatolozi.Count > 5)
            {
                recommendedStomatolozi = recommendedStomatolozi.Take(5).ToList();
            }

            var mappedList = _mapper.Map<List<Model.Korisnik>>(recommendedStomatolozi);

            foreach (var item in mappedList)
            {
                item.ProsjecnaOcjena = _db.Ocjenes.Where(x => x.KorisnikId == item.KorisnikID).Average(x => (decimal?)x.Ocjena) ?? 0m;
            }

            return mappedList;
        }

        private void LoadStomatologRatings(int stomatologId)
        {
            // get stomatologs that are still available to see
            var activeStomatologs = _db.Korisniks.Where(x => x.KorisnikId != stomatologId && x.Uloga.Naziv == "Stomatolog").ToList();

            List<Database.Ocjene> ratings;
            foreach (Database.Korisnik item in activeStomatologs)
            {
                // get ratings for stomatologs
                ratings = _db.Ocjenes.Where(s => s.KorisnikId == item.KorisnikId).OrderBy(x => x.PacijentId).ToList();
                if (ratings.Count > 0)
                {
                    stomatologRatings.Add(item.KorisnikId, ratings);
                }
            }
        }

        private static double GetSimilarity(List<Database.Ocjene> commonRatings1, List<Database.Ocjene> commonRatings2)
        {
            if (commonRatings1.Count != commonRatings2.Count)
                return 0;
            double counter = 0, denominator1 = 0, denominator2 = 0;

            for (int i = 0; i < commonRatings1.Count; i++)
            {
                counter = Convert.ToDouble(commonRatings1[i].Ocjena * commonRatings2[i].Ocjena);
                denominator1 = Convert.ToDouble(commonRatings2[i].Ocjena * commonRatings1[i].Ocjena);
                denominator2 = Convert.ToDouble(commonRatings1[i].Ocjena * commonRatings2[i].Ocjena);
            }
            denominator1 = Math.Sqrt(denominator1);
            denominator2 = Math.Sqrt(denominator2);
            double denominator = denominator1 * denominator2;
            if (denominator == 0)
                return 0;
            return counter / denominator;
        }
    }
}
