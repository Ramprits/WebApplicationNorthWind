using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationNorthWind.SampleDb.SampleEntities
{
    public partial class SampledbContext : DbContext
    {
        public SampledbContext(DbContextOptions<SampledbContext> options)
             : base(options)
        {
        }
        public virtual DbSet<Fruits> Fruits { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductDescription> ProductDescription { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=SampleDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fruits>(entity =>
            {
                entity.HasKey(e => e.FruitId)
                    .HasName("PK_Fruits");

                entity.Property(e => e.FruitId).HasDefaultValueSql("newid()");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("CreatedDT")
                    .HasColumnType("date")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.ImgPath).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });
        }
    }
}