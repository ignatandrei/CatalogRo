using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatalogDAL.Models
{
    public partial class CatalogROContext : DbContext
    {
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Entuziast> Entuziast { get; set; }
        public virtual DbSet<Format> Format { get; set; }
        public virtual DbSet<Resursa> Resursa { get; set; }
        public virtual DbSet<ResursaDict> ResursaDict { get; set; }
        public virtual DbSet<ResursaInregistrare> ResursaInregistrare { get; set; }
        public virtual DbSet<ResursaValoare> ResursaValoare { get; set; }

        // Unable to generate entity type for table 'dbo.ResursaAlternativa'. Please see the warning messages.

        

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

            modelBuilder.Entity<Entuziast>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.Nume).HasMaxLength(500);

                entity.Property(e => e.Parola).IsRequired();

                entity.Property(e => e.Prenume).HasMaxLength(500);

                entity.Property(e => e.Telefon).HasMaxLength(500);
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

                entity.HasOne(d => d.CategorieNavigation)
                    .WithMany(p => p.Resursa)
                    .HasForeignKey(d => d.Categorie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resursa_Categorie");

                entity.HasOne(d => d.FormatNavigation)
                    .WithMany(p => p.Resursa)
                    .HasForeignKey(d => d.Format)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resursa_Format");

                entity.HasOne(d => d.Unique)
                    .WithMany(p => p.Resursa)
                    .HasForeignKey(d => d.UniqueId)
                    .HasConstraintName("FK_Resursa_ResursaInregistrare");
            });

            modelBuilder.Entity<ResursaDict>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TableValue).HasMaxLength(50);

                entity.Property(e => e.Valoare)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ResursaInregistrare>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DataIntroducere)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Identuziast).HasColumnName("IDEntuziast");

                entity.HasOne(d => d.IdentuziastNavigation)
                    .WithMany(p => p.ResursaInregistrare)
                    .HasForeignKey(d => d.Identuziast)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResursaInregistrare_Entuziast");
            });

            modelBuilder.Entity<ResursaValoare>(entity =>
            {
                entity.HasKey(e => new { e.IdresursaDict, e.UniqueId });

                entity.Property(e => e.IdresursaDict).HasColumnName("IDResursaDict");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Valoare).HasColumnType("nchar(10)");

                entity.HasOne(d => d.IdresursaDictNavigation)
                    .WithMany(p => p.ResursaValoare)
                    .HasForeignKey(d => d.IdresursaDict)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResursaValoare_ResursaDict");

                entity.HasOne(d => d.Unique)
                    .WithMany(p => p.ResursaValoare)
                    .HasForeignKey(d => d.UniqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResursaValoare_ResursaInregistrare");
            });
        }
    }
}
