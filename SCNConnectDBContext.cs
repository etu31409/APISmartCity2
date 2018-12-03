using System;
using APISmartCity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APISmartCity
{
    public partial class SCNConnectDBContext : DbContext
    {
        public SCNConnectDBContext()
        {
        }

        public SCNConnectDBContext(DbContextOptions<SCNConnectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actualite> Actualite { get; set; }
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Commerce> Commerce { get; set; }
        public virtual DbSet<Horaire> Horaire { get; set; }
        public virtual DbSet<ImageCommerce> ImageCommerce { get; set; }
        public virtual DbSet<Personne> Personne { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=sc-nconnect-db.database.windows.net;Database=SC-NConnect-DB;User Id=dbadminSC;Password=azertyuiop123*;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actualite>(entity =>
            {
                entity.HasKey(e => e.IdActualite);

                entity.Property(e => e.IdActualite).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Texte)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCommerceNavigation)
                    .WithMany(p => p.Actualite)
                    .HasForeignKey(d => d.IdCommerce)
                    .HasConstraintName("FK__Actualite__IdCom__5812160E");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.IdCategorie);

                entity.Property(e => e.IdCategorie).ValueGeneratedNever();

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Commerce>(entity =>
            {
                entity.HasKey(e => e.IdCommerce);

                entity.Property(e => e.IdCommerce).ValueGeneratedNever();

                entity.Property(e => e.AdresseMail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomCommerce)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ParcoursProduitPhare)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProduitPhare)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Rue)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UrlPageFacebook)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategorieNavigation)
                    .WithMany(p => p.Commerce)
                    .HasForeignKey(d => d.IdCategorie)
                    .HasConstraintName("FK__Commerce__IdCate__4BAC3F29");
            });

            modelBuilder.Entity<Horaire>(entity =>
            {
                entity.HasKey(e => e.IdHoraire);

                entity.Property(e => e.IdHoraire).ValueGeneratedNever();

                entity.Property(e => e.HoraireDebut).HasColumnType("datetime");

                entity.Property(e => e.HoraireFin).HasColumnType("datetime");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ImageCommerce>(entity =>
            {
                entity.HasKey(e => e.IdImageCommerce);

                entity.Property(e => e.IdImageCommerce)
                    .HasColumnName("idImageCommerce")
                    .ValueGeneratedNever();

                entity.Property(e => e.Url)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCommerceNavigation)
                    .WithMany(p => p.ImageCommerce)
                    .HasForeignKey(d => d.IdCommerce)
                    .HasConstraintName("FK__ImageComm__IdCom__4E88ABD4");
            });

            modelBuilder.Entity<Personne>(entity =>
            {
                entity.HasKey(e => e.IdPersonne);

                entity.Property(e => e.IdPersonne).ValueGeneratedNever();

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MotDePasse)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCommerceNavigation)
                    .WithMany(p => p.Personne)
                    .HasForeignKey(d => d.IdCommerce)
                    .HasConstraintName("FK__Personne__IdComm__5535A963");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.HasKey(e => e.IdPromotion);

                entity.Property(e => e.IdPromotion).ValueGeneratedNever();

                entity.Property(e => e.Conditions)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DateDeb).HasColumnType("date");

                entity.Property(e => e.DateFin).HasColumnType("date");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
