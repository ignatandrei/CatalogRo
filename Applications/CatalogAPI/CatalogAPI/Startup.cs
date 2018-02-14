using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogDAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace CatalogAPI
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
            services.AddMvc();
            services.AddSingleton<CatalogROContext>(
                new CatalogROContext());
            //services.AddDbContext<CatalogROContext>(options 
            //    => options.UseInMemoryDatabase(databaseName: "Add_writes_to_database")
            //    );
            Seed(services.BuildServiceProvider().GetRequiredService<CatalogROContext>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Is This Taxi Legal API", Version = "v1" });
                //var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "TaxiWebAndAPI.xml");
                //c.IncludeXmlComments(filePath);
            });
        }

        private void Seed(CatalogROContext catalogROContext)
        {

            var cBeletristica = new Categorie();
            cBeletristica.Nume = "Beletristica";
            catalogROContext.Categorie.Add(cBeletristica);
            var cPoezie = new Categorie();
            cPoezie.Nume = "Poezie";
            cPoezie.ParentNavigation = cBeletristica;
            catalogROContext.Categorie.Add(cPoezie);

            var cDrama = new Categorie();
            cDrama.Nume = "Drama";
            cDrama.ParentNavigation = cBeletristica;
            catalogROContext.Categorie.Add(cDrama);
            var cAltele = new Categorie(); cAltele.Nume = "Altele"; catalogROContext.Categorie.Add(cAltele);
            var cEseu = new Categorie(); cEseu.Nume = "Eseu"; catalogROContext.Categorie.Add(cEseu);
            var cCronica = new Categorie(); cCronica.Nume = "Cronica"; catalogROContext.Categorie.Add(cCronica);
            catalogROContext.SaveChanges();

            Format f = null;
            f=new Format();
            f.Nume = "PDF";
            catalogROContext.Format.Add(f);

            f = new Format();
            f.Nume = "JPG";
            catalogROContext.Format.Add(f);

            f = new Format();
            f.Nume = "TXT";
            catalogROContext.Format.Add(f);

            catalogROContext.SaveChanges();




        }

        //This method gets called by the runtime.Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Is This Taxi Legal API");

            });
        }
    }
}
