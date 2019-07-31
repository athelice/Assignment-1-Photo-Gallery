
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogApi.Domain;

namespace EventCatalogApi.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options)

            : base(options)
        {


        }
        public DbSet<EventType> EventTypes { get; set; }

        public DbSet<EventCity> EventCities { get; set; }

        public DbSet<EventItem> EventItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // instruct the builder to build your table
        {
            modelBuilder.Entity<EventType>(ConfigureEventType);
            modelBuilder.Entity<EventCity>(ConfigureEventCity);
            modelBuilder.Entity<EventItem>(ConfigureEventItem);
        }
        private void ConfigureEventType(EntityTypeBuilder<EventType> builder)
        {
            builder.ToTable("EventTypes");
            builder.Property(c => c.Id) //building columns
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_type_hilo");
            builder.Property(c => c.Type)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureEventCity(EntityTypeBuilder<EventCity> builder)
        {
            builder.ToTable("EventCities");
            builder.Property(c => c.Id) //building columns
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_city_hilo");
            builder.Property(c => c.City)
                .IsRequired()
                .HasMaxLength(100);

        }
        private void ConfigureEventItem(EntityTypeBuilder<EventItem> builder)
        {
            builder.ToTable("EventCatalog");
            builder.Property(c => c.Id) //building columns
             .IsRequired()
             .ForSqlServerUseSequenceHiLo("catalog_hilo");
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Price)
              .IsRequired();

            builder.Property(c => c.Address)
             .IsRequired()
            .HasMaxLength(200);

            builder.Property(c => c.EventDate)
                 .IsRequired();

            builder.HasOne(c => c.EventType)
                .WithMany()
                .HasForeignKey(c => c.EventTypeId);

            builder.HasOne(c => c.EventCity)
                .WithMany()
                .HasForeignKey(c => c.EventCityId);
        }

  

     
    }
}