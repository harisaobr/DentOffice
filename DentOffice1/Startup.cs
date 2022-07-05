using DentOffice.WebAPI.Database;
using DentOffice.Model.Requests;
using DentOffice.WebAPI.Filters;
using DentOffice.WebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentOffice.WebAPI.Services.Interfaces;
using DentOffice.WebAPI.Controllers;
using DentOffice.WebAPI.Security;
using Microsoft.AspNetCore.Authentication;

namespace DentOffice1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DentOffice.WebAPI", Version = "v1" });

                c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                        },
                        new string[]{}
                    }
                });
            });

            services.AddScoped<IKorisnikService, KorisnikService>();
            services.AddScoped<ITerminService, TerminService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IIzvjestajService, IzvjestajService>();
            services.AddScoped<IRecommenderService, RecommendedService>();
            services.AddScoped<ICRUDService<DentOffice.Model.Dijagnoza, DijagnozaSearchRequest, DijagnozaInsertRequest, DijagnozaInsertRequest>, DijagnozaService>();
            services.AddScoped<IService<DentOffice.Model.Uloga, object>, BaseService<DentOffice.Model.Uloga, object, Uloga>>();
            services.AddScoped<IService<DentOffice.Model.Usluga, object>, BaseService<DentOffice.Model.Usluga, object, Usluga>>();
            services.AddScoped<IService<DentOffice.Model.Grad, object>, BaseService<DentOffice.Model.Grad, object, Grad>>();
            services.AddScoped<ICRUDService<DentOffice.Model.Grad, GradSearchRequest, GradUpsertRequest, GradUpsertRequest>, GradService>();
            services.AddScoped<ICRUDService<DentOffice.Model.Drzava, DrzavaSearchRequest, DrzavaUpsertRequest, DrzavaUpsertRequest>, DrzavaService>();
            services.AddScoped<ICRUDService<DentOffice.Model.Lijek, LijekSearchRequest, LijekUpsertRequest, LijekUpsertRequest>, LijekService>();
            services.AddScoped<ICRUDService<DentOffice.Model.MedicinskiKarton, MedicinskiKartonSearchRequest, MedicinskiKartonUpsertRequest, MedicinskiKartonUpsertRequest>, MedicinskiKartonService>();
            services.AddScoped<ICRUDService<DentOffice.Model.Pregled, PregledSearchRequest, PregledUpsertRequest, PregledUpsertRequest>, PregledService>();
            services.AddScoped<ICRUDService<DentOffice.Model.Uloga, UlogaSearchRequest, UlogaUpsertRequest, UlogaUpsertRequest>, UlogaService>();
            services.AddScoped<ICRUDService<DentOffice.Model.Usluga, UslugaSearchRequest, UslugaUpsertRequest, UslugaUpsertRequest>, UslugaService>();
            services.AddScoped<ICRUDService<DentOffice.Model.Racun, RacunSearchRequest, RacunInsertRequest, RacunInsertRequest>, RacunService>();
            services.AddScoped<ICRUDService<DentOffice.Model.Ocjene, OcjeneSearchRequest, OcjeneUpsertRequest, OcjeneUpsertRequest>, OcjenaService>();


            services.AddDbContext<eDentOfficeContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("UserDatabase"));
            }, ServiceLifetime.Transient);

            //services.AddDbContext<eDentOfficeContext>(options => {
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection"));
            //}, ServiceLifetime.Transient);
            services.AddCors(o => o.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DentOffice.WebAPI v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
         
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
