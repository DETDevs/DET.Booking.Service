
using DET.Booking.BusinessLogic.Interfaces;

namespace DET.Booking.Service.Worker
{
    public class ReservaReminderService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;

        public ReservaReminderService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(60));
            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            using var scope = _scopeFactory.CreateScope();

            var reservaLogic = scope.ServiceProvider.GetRequiredService<IBooking>();
            var reservas = await reservaLogic.GetNextReservations();

            foreach (var reserva in reservas)
            {
                await reservaLogic.SendAsyncReminder(reserva);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose() => _timer?.Dispose();
    }
}
