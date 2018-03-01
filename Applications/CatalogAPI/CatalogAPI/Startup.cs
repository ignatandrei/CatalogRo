using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CatalogDAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
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
            services.AddDirectoryBrowser();
            //services.AddOptions();
            services.AddMvc();
            //services.AddScoped<CatalogROContext>();
            var connection = @"Data Source=CatalogRo.sqlite3;";
            services.AddDbContext<CatalogROContext>(options => options.UseSqlite(connection));

            //services.AddDbContext<CatalogROContext>(options 
            //    => options.UseInMemoryDatabase(databaseName: "Add_writes_to_database")
            //    );
            //Seed(services.BuildServiceProvider().GetRequiredService<CatalogROContext>());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Catalog RO API", Version = "v1" });
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


            app.Use(async (context, next) => {
                await next();
                if (context.Response.StatusCode == 404 &&
                   !Path.HasExtension(context.Request.Path.Value) &&
                   !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
           
            //app.UseMvc(routes =>
            //{

            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});


            //app.UseDirectoryBrowser(new DirectoryBrowserOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
            //    RequestPath = "/"
            //});

            //app.Use(async (context, next) =>
            //{

            //    // Do work that doesn't write to the Response.
            //    await next.Invoke();
            //    // Do logging or other work that doesn't write to the Response.
            //});


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog RO");

            });
        }
    }
}
