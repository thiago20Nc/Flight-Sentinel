using FlightSentinel.Domain.Entities;
using FlightSentinel.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace FlightSentinel.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<PriceAlert> PriceAlerts { get; set; }
        public DbSet<PriceCheckHistory> PriceCheckHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new PriceAlertConfig());
            modelBuilder.ApplyConfiguration(new PriceCheckHistoryConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
