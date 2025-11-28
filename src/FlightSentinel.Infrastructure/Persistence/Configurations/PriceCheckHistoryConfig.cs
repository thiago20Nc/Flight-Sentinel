using FlightSentinel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightSentinel.Infrastructure.Persistence.Configurations
{
    public class PriceCheckHistoryConfig : IEntityTypeConfiguration<PriceCheckHistory>
    {
        public void Configure(EntityTypeBuilder<PriceCheckHistory> builder)
        {
            builder.ToTable("PriceCheckHistories");
            builder.HasKey(h => h.HistoryId);

            builder.Property(h => h.FoundPrice)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(h => h.FoundAt)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(h => h.Airline)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(h => h.Alert)
                   .WithMany(a => a.History)
                   .HasForeignKey(h => h.AlertId)
                   .OnDelete(DeleteBehavior.Cascade);

            // índices úteis
            builder.HasIndex(h => h.AlertId);
        }
    }
}
