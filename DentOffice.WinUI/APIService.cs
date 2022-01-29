using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using DentOffice.Model;
using System.Windows.Forms;
using DentOffice.WinUI.Properties;

namespace DentOffice.WinUI
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
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            if (action != null)
                url += $"/{action}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }
            
            try
            {
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                object errors = null;
                try
                {
                    errors = await ex.GetResponseJsonAsync<object>();
                }
                catch (Exception)
                {
                    errors = await ex.GetResponseStringAsync();
                }

                MessageBox.Show(errors.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }
        public async Task<T> GetById<T>(object id, string action = null)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            if (action != null)
                url += $"/{action}";
            url += $"/{id}";

            try
            {
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                object errors = null;
                try
                {
                    errors = await ex.GetResponseJsonAsync<object>();
                }
                catch (Exception)
                {
                    errors = await ex.GetResponseStringAsync();
                }

                MessageBox.Show(errors.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }
        public async Task<T> Insert<T>(object request, string action = null)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            if (action != null)
                url += $"/{action}";

            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                object errors = null;
                try
                {
                    errors = await ex.GetResponseJsonAsync<object>();
                }
                catch (Exception)
                {
                    errors = await ex.GetResponseStringAsync();
                }

                MessageBox.Show(errors.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }

        }
        public async Task<T> Update<T>(object id, object request, string action = null)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            if (action != null)
                url += $"/{action}";
            url += $"/{id}";

            try
            {
                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                object errors = null;
                try
                {
                    errors = await ex.GetResponseJsonAsync<object>();
                }
                catch (Exception)
                {
                    errors = await ex.GetResponseStringAsync();
                }

                MessageBox.Show(errors.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }

        }
    }
}

