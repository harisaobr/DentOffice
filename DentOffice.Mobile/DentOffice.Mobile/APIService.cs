using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using DentOffice.Model;
using Xamarin.Forms;

namespace DentOffice.Mobile
{      

    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static Korisnik PrijavljeniKorisnik { get; set; }

        private string APIUrl;
        private readonly string _route;
        public APIService(string route)
        {
            _route = route;
            APIUrl = getApiURL();
        }

        public static string getApiURL()
        {
            int port = 59296;
            string local = $"http://localhost:{port}/api";

            return local;
        }

        public async Task<T> Get<T>(object search, string action = null)
        {
            var url = $"{APIUrl}/{_route}";
            try
            {
                if (action != null)
                {
                    url += "/" + action;
                }

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                return await HandleException<T>(ex);
            }
        }

        public async Task<T> GetById<T>(object id, string action = null)
        {
            var url = $"{APIUrl}/{_route}";
            try
            {
                if (action != null)
                {
                    url += $"/{action}";
                }
                url += $"/{id}";
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                return await HandleException<T>(ex);
            }
        }

        public async Task<T> Insert<T>(object request, string action = null)
        {
            var url = $"{APIUrl}/{ _route}";
            if (action != null)
            {
                url += $"/{action}";
            }
            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                return await HandleException<T>(ex);
            }

        }

        public async Task<T> Update<T>(int id, object request, string action = null)
        {
            try
            {
                var url = $"{APIUrl}/{ _route}";
                if (action != null)
                {
                    url += $"/{action}";
                }
                url += $"/{id}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                return await HandleException<T>(ex);
            }

        }
        public async Task<T> Delete<T>(int id)
        {
            var url = $"{APIUrl}/{_route}/{id}";

            try
            {
                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                return await HandleException<T>(ex);
            }
        }

        private static async Task<T> HandleException<T>(FlurlHttpException ex)
        {
            if (ex.StatusCode == (int)System.Net.HttpStatusCode.Unauthorized)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Neuspješna prijava", "OK");
                return default;
            }
            if (ex.StatusCode == (int)System.Net.HttpStatusCode.Forbidden)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Niste autorizovani", "OK");
                return default;
            }
            var response = await ex.GetResponseStringAsync();

            await Application.Current.MainPage.DisplayAlert("Greška", response, "OK");
            return default;
        }
    }
}

