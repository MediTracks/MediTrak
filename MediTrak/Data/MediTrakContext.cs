using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MediTrak.Data
{
    public partial class MediTrakContext : DbContext
    {
        public MediTrakContext()
        {
        }

        public MediTrakContext(DbContextOptions<MediTrakContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Approvisionnement> Approvisionnements { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<ConfirmationReception> ConfirmationReceptions { get; set; }
        public virtual DbSet<Depot> Depots { get; set; }
        public virtual DbSet<Distribution> Distributions { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Structure> Structures { get; set; }
        public virtual DbSet<Transporteur> Transporteurs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ville> Villes { get; set; }
        public virtual DbSet<Zone> Zones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=MediTrak");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Approvisionnement>(entity =>
            {
                entity.ToTable("Approvisionnement");

                entity.Property(e => e.CoutTotal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DateExpiration).HasColumnType("date");

                entity.Property(e => e.DateFabrication).HasColumnType("date");

                entity.HasOne(d => d.Depot)
                    .WithMany(p => p.Approvisionnements)
                    .HasForeignKey(d => d.DepotId)
                    .HasConstraintName("FK_Approvisionnement_Depot");

                entity.HasOne(d => d.Fournisseur)
                    .WithMany(p => p.Approvisionnements)
                    .HasForeignKey(d => d.FournisseurId)
                    .HasConstraintName("FK_Approvisionnement_Fournisseur");

                entity.HasOne(d => d.Produit)
                    .WithMany(p => p.Approvisionnements)
                    .HasForeignKey(d => d.ProduitId)
                    .HasConstraintName("FK_Approvisionnement_Produit");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.ToTable("Categorie");

                entity.Property(e => e.Descritption)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.ToTable("Commande");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.NumCommand)
                    .HasColumnName("Num_Command")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ConfirmationReception>(entity =>
            {
                entity.ToTable("ConfirmationReception");

                entity.Property(e => e.DateConfirmation).HasColumnType("date");

                entity.Property(e => e.Observations).HasMaxLength(3000);

                entity.Property(e => e.QteRecue).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Commande)
                    .WithMany(p => p.ConfirmationReceptions)
                    .HasForeignKey(d => d.CommandeId)
                    .HasConstraintName("FK_ConfirmationReception_Commande");
            });

            modelBuilder.Entity<Depot>(entity =>
            {
                entity.ToTable("Depot");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Nom).HasMaxLength(50);
            });

            modelBuilder.Entity<Distribution>(entity =>
            {
                entity.ToTable("Distribution");

                entity.Property(e => e.DateDistribution).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Quantite).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Approvisionnement)
                    .WithMany(p => p.Distributions)
                    .HasForeignKey(d => d.ApprovisionnementId)
                    .HasConstraintName("FK_Distribution_Approvisionnement");

                entity.HasOne(d => d.Commande)
                    .WithMany(p => p.Distributions)
                    .HasForeignKey(d => d.CommandeId)
                    .HasConstraintName("FK_Distribution_Commande");

                entity.HasOne(d => d.Transporteur)
                    .WithMany(p => p.Distributions)
                    .HasForeignKey(d => d.TransporteurId)
                    .HasConstraintName("FK_Distribution_Transporteur");
            });

            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.ToTable("Fournisseur");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Telephone).HasMaxLength(50);
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.ToTable("Produit");

                entity.Property(e => e.CategorieId).HasColumnName("Categorie_Id");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Nom).HasMaxLength(500);

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Produits)
                    .HasForeignKey(d => d.CategorieId)
                    .HasConstraintName("FK_Produits_Produits");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Province");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Nom).HasMaxLength(50);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("Stock");

                entity.Property(e => e.DateStock).HasColumnType("date");

                entity.Property(e => e.Desigantion).HasMaxLength(50);

                entity.Property(e => e.Numero).HasMaxLength(50);

                entity.Property(e => e.QteEntree).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.QteSortie).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StockFinal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StockInitial).HasMaxLength(50);
            });

            modelBuilder.Entity<Structure>(entity =>
            {
                entity.ToTable("Structure");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Telephone).HasMaxLength(50);

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.InverseZone)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("FK_Structure_Structure");
            });

            modelBuilder.Entity<Transporteur>(entity =>
            {
                entity.ToTable("Transporteur");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Nom).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PostNom).HasMaxLength(50);

                entity.Property(e => e.Prenom).HasMaxLength(50);
            });

            modelBuilder.Entity<Ville>(entity =>
            {
                entity.ToTable("Ville");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceId).HasColumnName("Province_Id");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Villes)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK_Villes_Provinces");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.ToTable("Zone");

                entity.Property(e => e.Addresse).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.ZoneCore)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
