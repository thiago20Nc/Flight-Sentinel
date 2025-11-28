using FlightSentinel.Domain.Interfaces;
using FlightSentinel.Infrastructure.Jobs;
using FlightSentinel.Infrastructure.Persistence;
using FlightSentinel.Infrastructure.Persistence.Repositories;
using FlightSentinel.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightSentinel.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPriceAlertRepository, PriceAlertRepository>();
            services.AddScoped<IPriceCheckHistoryRepository, PriceCheckHistoryRepository>();

            // External services
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IFlightPriceProvider, FlightPriceProvider>();

            // Jobs (if using Hangfire)
            services.AddScoped<IPriceCheckJob, PriceCheckJob>();


            return services;
        }
    }
}
