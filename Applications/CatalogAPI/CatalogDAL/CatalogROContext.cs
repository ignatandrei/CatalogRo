using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogDAL.Models
{
    public partial class CatalogROContext
    {
        public CatalogROContext(DbContextOptions<CatalogROContext> options)
    : base(options)
        { }
        public CatalogROContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer(@"Server=.;Database=CatalogRO;Trusted_Connection=True;");
                //optionsBuilder.UseInMemoryDatabase(databaseName: "Add_writes_to_database");
                var connection = @"Data Source=CatalogRO.sqlite3;";

                optionsBuilder.UseSqlite(connection);
            }
        }
    }
}
