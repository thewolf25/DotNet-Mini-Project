using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace miniProject.Models
{
    public partial class DbProjetContext : DbContext
    {
        public DbProjetContext()
        {
        }

        public DbProjetContext(DbContextOptions<DbProjetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=THEWOLF\\MSSQLSERVER02; Initial Catalog = DbProjet; Integrated Security = true; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Chemin)
                    .HasMaxLength(300)
                    .IsFixedLength(true);

                entity.Property(e => e.Nom)
                    .HasMaxLength(300)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdProduitNavigation)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.IdProduit)
                    .HasConstraintName("FK_Images_Produit");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.ToTable("Produit");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .IsFixedLength(true);

                entity.Property(e => e.Reference).HasMaxLength(300);
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.ToTable("Utilisateur");

                entity.Property(e => e.Email)
                    .HasMaxLength(300)
                    .IsFixedLength(true);

                entity.Property(e => e.Motdepasse)
                    .HasMaxLength(300)
                    .IsFixedLength(true);

                entity.Property(e => e.Role)
                    .HasMaxLength(300)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        internal void Add(Image image)
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
