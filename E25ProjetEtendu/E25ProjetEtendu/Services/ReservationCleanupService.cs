using E25ProjetEtendu.Services.IServices;

namespace E25ProjetEtendu.Services
{
    public class ReservationCleanupService : BackgroundService
    {
        private readonly IProduitService _produitService;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(1); // Runs every 1 minute

        public ReservationCleanupService(IProduitService produitService)
        {
            _produitService = produitService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _produitService.CleanupExpiredReservations();
                await Task.Delay(_interval, stoppingToken);
            }
        }
    }
}
