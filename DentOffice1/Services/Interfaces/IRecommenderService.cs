using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services.Interfaces
{
    public interface IRecommenderService
    {
        List<Model.Korisnik> GetRecommendedStomatolog(int stomatolog);
    }
}
