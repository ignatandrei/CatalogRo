using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CatalogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DownloadDatabase().GetAwaiter().GetResult();
            BuildWebHost(args).Run();
        }
        static async Task DownloadDatabase()
        {
            if (!File.Exists("CatalogRo.sqlite3"))
            {
                var url = "https://raw.githubusercontent.com/ignatandrei/CatalogRO/master/SqlData/CatalogRo.sqlite3";
                using (var client = new HttpClient())
                {

                    using (var result = await client.GetAsync(url))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var bytes = await result.Content.ReadAsByteArrayAsync();
                            File.WriteAllBytes("CatalogRo.sqlite3", bytes);
                        }

                    }
                }
            }
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
