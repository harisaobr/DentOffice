using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services.Interfaces
{
    public interface IOcjeneService
    {
        List<Model.Korisnik> GetRecommendedStomatolog();
    }
}
