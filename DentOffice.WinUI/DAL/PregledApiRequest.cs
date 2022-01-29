using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentOffice.Model;
using Flurl.Http;

namespace DentOffice.WinUI.DAL
{
    class PregledApiRequest : IGetRequest
    {
        private readonly string _endpoint;
        public PregledApiRequest()
        {
            _endpoint = ConfigurationManager.AppSettings["PregledUrl"];

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
