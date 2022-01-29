using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentOffice.WinUI.DAL
{
    public interface IGetRequest
    {
        Task<T> Get<T>(object search) where T : class;
        Task<T> GetById<T>(object id) where T : class;
    }
}
