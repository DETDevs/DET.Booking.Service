using Microsoft.AspNetCore.SignalR;


namespace DET.Booking.Extensions
{
    public class NotificacionService
    {
        private readonly IHubContext<NotificacionHub> _hubContext;

        public NotificacionService(IHubContext<NotificacionHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task EnviarNotificacionAsync(string mensaje)
        {
            await _hubContext.Clients.All.SendAsync("RecibirNotificacion", mensaje);
        }
    }
}
