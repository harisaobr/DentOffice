using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using System.Threading.Tasks;
using DentOffice.WebAPI.Services;

namespace DentOffice.WebAPI.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IKorisnikService _korisnikService;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IKorisnikService korisnikService) : base(options, logger, encoder, clock)
        {
            _korisnikService = korisnikService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing authorization header");
            }

            Model.Korisnik korisnik;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                korisnik = await _korisnikService.Login(username, password);
            }
            catch (Exception)
            {
                return AuthenticateResult.Fail("Incorrect username or password");
            }

            if (korisnik is null)
                return AuthenticateResult.Fail("Invalid username or password");

            _korisnikService.SetLogiraniKorisnik(korisnik);
            string korisnickoIme = korisnik.KorisnickoIme;
            string ime = korisnik.Ime;
            string uloga = korisnik.Uloga.Naziv;

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, korisnickoIme),
                new Claim(ClaimTypes.Name, ime),
            };

            claims.Add(new Claim(ClaimTypes.Role, uloga));

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }


    }
}