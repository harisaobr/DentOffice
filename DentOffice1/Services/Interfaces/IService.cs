using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentOffice.WebAPI.Services
{
    public interface IService<T, TSearch>
    {
        IList<T> GetAll(TSearch search = default(TSearch));

        T GetById(int id);
    }
}
