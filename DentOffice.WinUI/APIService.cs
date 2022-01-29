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
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DentOffice.WinUI
{

    public class APIService
    {
        private string _route = null;
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static int Permisije { get; set; }
        public static Model.Korisnik LogiraniKorisnik { get; set; }

        public APIService(string route)
        {
            _route = route;
        }
        public async Task<T> GetAll<T>(object search = null, string action = null)
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
                await HandleFlurlException(ex);
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
                await HandleFlurlException(ex);
                return default;
            }
        }

        private static async Task HandleFlurlException(FlurlHttpException ex)
        {
            if (ex.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("Greška prilikom authentifikacje.", "Neautorizovani pristup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ex.StatusCode == (int)HttpStatusCode.Forbidden)
            {
                MessageBox.Show("Nemate pravo pristupa.", "Zabranjen pristup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            object errors = null;
            try
            {
                errors = await ex.GetResponseJsonAsync<ValidationProblemDetails>();
                if (errors is ValidationProblemDetails e1)
                {
                    var stringBuilder = new StringBuilder();
                    foreach (var error in e1.Errors)
                    {
                        stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                    }
                    foreach (var error in e1.Extensions)
                    {
                        stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                    }

                    MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception)
            {
                try
                {
                    errors = await ex.GetResponseJsonAsync<object>();

                }
                catch (Exception)
                {
                    errors = await ex.GetResponseStringAsync();
                }
                MessageBox.Show(errors.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                await HandleFlurlException(ex);

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
                await HandleFlurlException(ex);

                return default;
            }

        }
    }
}

