using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{   //class is an entity framework class
    public class CatalogContext :DbContext
    {   //made class injectable 
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }
        //CatalogBrands(plural) - > refers to table
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogBrand>(ConfigureCatalogBrand);
            modelBuilder.Entity <CatalogType>(ConfigureCatalogType);
            modelBuilder.Entity<CatalogItem>(ConfigureCatalogItem);


        }

        private void ConfigureCatalogType(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogTypes"); // make a table
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_type_hilo"); //autogenerate primary key
            builder.Property(c => c.Type)
            .IsRequired()
            .HasMaxLength(100);
        }

        private void ConfigureCatalogItem(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog"); // make a table
            builder.Property(c => c.Id)
           .IsRequired()
           .ForSqlServerUseSequenceHiLo("catalog_hilo");
            builder.Property(c => c.Name)
           .IsRequired()
           .HasMaxLength(50);
            builder.Property(c => c.Price)
         .IsRequired();
            builder.HasOne(c => c.CatalogType)
                .WithMany()
                .HasForeignKey(c => c.CatalogTypeId);
            builder.HasOne(c => c.CatalogBrand)
              .WithMany()
              .HasForeignKey(c => c.CatalogBrandId);
           
            

        }

        private void ConfigureCatalogBrand(
            EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrands"); // make a table
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_brand_hilo"); //autogenerate primary key
            builder.Property(c => c.Brand)
            .IsRequired()
            .HasMaxLength(100);
        }
    }

}
