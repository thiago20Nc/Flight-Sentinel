using FlightSentinel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightSentinel.Infrastructure.Persistence.Configurations
{
    public class PriceAlertConfig : IEntityTypeConfiguration<PriceAlert>
    {
        public void Configure(EntityTypeBuilder<PriceAlert> builder)
        {
            builder.ToTable("PriceAlerts");
            builder.HasKey(a => a.AlertId);

            builder.Property(a => a.OriginAirport)
                   .IsRequired()
                   .HasMaxLength(3);

            builder.Property(a => a.DestinationAirport)
                   .IsRequired()
                   .HasMaxLength(3);

            builder.Property(a => a.MaxPrice)
                   .HasColumnType("decimal(10,2)");

            builder.Property(a => a.Status)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(a => a.User)
                   .WithMany(u => u.Alerts)
                   .HasForeignKey(a => a.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.History)
                   .WithOne(h => h.Alert)
                   .HasForeignKey(h => h.AlertId);

            // índices úteis
            builder.HasIndex(a => new { a.UserId });
        }
    }
}
