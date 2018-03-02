using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatalogDAL.Models
{
    public partial class CatalogROContext : DbContext
    {
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Format> Format { get; set; }
        public virtual DbSet<Resursa> Resursa { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.Idcategorie);

                entity.Property(e => e.Idcategorie).HasColumnName("IDCategorie");

                entity.Property(e => e.EnglishName).HasMaxLength(150);

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.ParentNavigation)
                    .WithMany(p => p.InverseParentNavigation)
                    .HasForeignKey(d => d.Parent)
                    .HasConstraintName("FK_Categorie_Categorie");
            });

            modelBuilder.Entity<Format>(entity =>
            {
                entity.HasKey(e => e.Idformat);

                entity.Property(e => e.Idformat).HasColumnName("IDFormat");

                entity.Property(e => e.EnglishName).HasMaxLength(150);

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Resursa>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Descriere).IsRequired();

                entity.Property(e => e.Subiect)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Titlu)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Url2Resursa).HasMaxLength(500);

                entity.Property(e => e.UrlResursa).HasMaxLength(500);
            });
        }
    }
}
