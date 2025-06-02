using DET.Booking.BusinessLogic.Extensions;
using DET.Booking.BusinessLogic.Interfaces;
using DET.Booking.Extensions;
using DET.Booking.Models;

namespace DET.Booking.BusinessLogic
{
    public class Booking : IBooking
    {
        private readonly DataAccess.Interfaces.IBooking? _booking;
        private readonly EmailService _emailService;
        private readonly NotificacionService _notificacionService;
        public Booking(DataAccess.Interfaces.IBooking? booking, EmailService emailService, NotificacionService notificacionService)
        {
            this._booking = booking;
            _emailService = emailService;
            _notificacionService = notificacionService;
        }

        public async Task<Response<string>> SaveReserve(Reservation reservation)
        {
            var result = await _booking.SaveReserve(reservation);

            if (result.IsSuccess)
            {
                //TODO: Envio de correo confirmando que se realizo la solicitud de reserva
                // Ruta del archivo HTML
                var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "template", "SuccessfulReservation.html");

                var emailBody = GetEmailBodyFromTemplate(templatePath, reservation.PersonName, reservation.Date);

                await _emailService.EnviarCorreoAsync(
                    reservation.PersonEmail,
                    "Test DET.Booking",
                    emailBody
                );

                //TODO: Envio de notifiacion (Hub)
                // Llama directamente al servicio de notificaciones
                await _notificacionService.EnviarNotificacionAsync("Se ha realizado una nueva reserva");
            }

            return result;
        }

        public async Task<Response<Reservation>> UpdateStateReserve(Reservation reservation)
        {
            var result = await _booking.UpdateStateReserve(reservation);

            if (result.IsSuccess)
            {
                //TODO: Envio de correo confirmando que se realizo la solicitud de reserva
                // Ruta del archivo HTML
                var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "template", "ReservationConfirmed.html");

                var emailBody = GetEmailBodyFromTemplate(templatePath, result.Content.PersonEmail, result.Content.Date);

                await _emailService.EnviarCorreoAsync(
                    result.Content.PersonEmail,
                    "Test DET.Booking Confirmed",
                    emailBody
                );

                //TODO: Envio de notifiacion (Hub) si se desea avisar que se confirmo la reserva
            }

            return result;
        }

        private string GetEmailBodyFromTemplate(string templatePath, string usuarioCorreo, DateTime fechaReserva)
        {
            string html = File.ReadAllText(templatePath);

            html = html.Replace("[usuarioCorreo]", usuarioCorreo);
            html = html.Replace("[fecha]", fechaReserva.ToString("dd/MM/yyyy"));
            html = html.Replace("[hora]", fechaReserva.ToString("hh:mm tt")); // o "HH:mm" si quieres en formato 24h

            return html;
        }

    }
}
