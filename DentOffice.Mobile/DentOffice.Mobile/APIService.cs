using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using DentOffice.Model;

namespace DentOffice.Mobile
{      

    public class APIService
    {
        private string _route = null;
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static int Permisije { get; set; }
        public static int KorisnikId { get; set; }
        public APIService(string route)
        {
            _route = route;
        }
        public async Task<T> GetAll<T>(object search, string action = null)
        {
            var url = $"{Properties.Resources.APIUrl}/{_route}";
            if (action != null)
                url += $"/{action}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }
            var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            return result;
        }
        public async Task<T> GetById<T>(object id, string action = null)
        {
            var url = $"{Properties.Resources.APIUrl}/{_route}";
            if (action != null)
                url += $"/{action}";
            url += $"/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request, string action = null)
        {
            var url = $"{Properties.Resources.APIUrl}/{_route}";
            if (action != null)
                url += $"/{action}";

            return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<T> Update<T>(object id, object request, string action = null)
        {
            var url = $"{Properties.Resources.APIUrl}/{_route}";
            if (action != null)
                url += $"/{action}";
            url += $"/{id}";

            return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
        }
    }
}

