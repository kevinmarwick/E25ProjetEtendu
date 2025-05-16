using E25ProjetEtendu.Services.IServices;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace E25ProjetEtendu.Services
{
    public class ReservationCleanupService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(1); // Runs every 1 minute
        private readonly ILogger<ReservationCleanupService> _logger;

        public ReservationCleanupService(IServiceScopeFactory scopeFactory, ILogger<ReservationCleanupService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var produitService = scope.ServiceProvider.GetRequiredService<IProduitService>();

                    try
                    {
                        await produitService.CleanupExpiredReservations();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error cleaning up expired reservations.");
                    }
                }

                await Task.Delay(_interval, stoppingToken);
            }
        }
    }
}
