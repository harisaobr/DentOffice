using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DentOffice.Model;

namespace DentOffice.WinUI.DAL
{
    class KorisnikApiRequest : IGetRequest
    {
        private readonly string _endpoint;
        public KorisnikApiRequest()
        {
            _endpoint = ConfigurationManager.AppSettings["KorisnikUrl"];

        }

        public Task<T> Get<T>(object search) where T : class
        {
            var url = _endpoint;

            if (search != null)
            {
                url += "?";
                url += search.ToQueryString();
            }

            var result = url.GetJsonAsync<T>();
            return result;
        }

        public Task<T> GetById<T>(object id) where T : class
        {
            var url = _endpoint;

            return url.GetJsonAsync<T>();
        }
      
    }
}
