#pragma warning disable 1591
using Microsoft.EntityFrameworkCore;

// https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db
// Scaffold-DbContext "Server=(localdb)\mssqllocaldb;AttachDBFilename='[App Root]\BrainWareCore\BrainWareCore\Data\DB\BrainWare.mdf';Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelsTemp

namespace BrainWareCore.Data
{
    public partial class BrainWareContext : DbContext
    {
        public BrainWareContext()
        {
        }

        public BrainWareContext(DbContextOptions<BrainWareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Orderproduct> Orderproduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_to_company");
            });

            modelBuilder.Entity<Orderproduct>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("orderproduct");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderproduct)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderproduct_order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderproduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderproduct_product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);

                entity.Property(e => e.Price).HasColumnName("price");
            });
        }
    }
}
#pragma warning restore 1591