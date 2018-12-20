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
        public virtual DbSet<ImageCommerce> ImageCommerce { get; set; }
        public virtual DbSet<OpeningPeriod> OpeningPeriod { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actualite>(entity =>
            {
                entity.HasKey(e => e.IdActualite);

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
                    .HasConstraintName("FK__Actualite__IdCom__4B7734FF");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.IdCategorie);

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Commerce>(entity =>
            {
                entity.HasKey(e => e.IdCommerce);

                entity.Property(e => e.AdresseMail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomCommerce)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ParcoursProduitPhare)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProduitPhare)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion();

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
                    .HasConstraintName("FK__Commerce__IdCate__42E1EEFE");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Commerce)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Commerce__IdPers__41EDCAC5");
            });

            modelBuilder.Entity<ImageCommerce>(entity =>
            {
                entity.HasKey(e => e.IdImageCommerce);

                entity.Property(e => e.IdImageCommerce).HasColumnName("idImageCommerce");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCommerceNavigation)
                    .WithMany(p => p.ImageCommerce)
                    .HasForeignKey(d => d.IdCommerce)
                    .HasConstraintName("FK__ImageComm__IdCom__45BE5BA9");
            });

            modelBuilder.Entity<OpeningPeriod>(entity =>
            {
                entity.HasKey(e => e.IdHoraire);

                entity.Property(e => e.IdCommerce).HasColumnName("idCommerce");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion();

                entity.HasOne(d => d.IdCommerceNavigation)
                    .WithMany(p => p.OpeningPeriod)
                    .HasForeignKey(d => d.IdCommerce)
                    .HasConstraintName("FK__OpeningPe__idCom__489AC854");
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Name);
            });

            modelBuilder.Entity<UserRole>(entity =>{
                entity.HasKey(e => new{e.IdRole, e.IdUser});

                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(e => e.IdUser);

                entity.HasOne(e => e.Role)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(e => e.IdRole);
            });
        }
    }
}
