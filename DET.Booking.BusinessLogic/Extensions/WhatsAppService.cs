
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace DET.Booking.BusinessLogic.Extensions
{
    public class WhatsAppService
    {
        private readonly DET.Booking.Extensions.CustomValuesConfiguration _customValuesConfiguratio;

        public WhatsAppService(IConfiguration config, DET.Booking.Extensions.CustomValuesConfiguration customValuesConfiguratio)
        {

            _customValuesConfiguratio = customValuesConfiguratio;
        }

        public async Task EnviarMensajeAsync(string telefonoDestino, string mensaje)
        {
            var TwiloConfig = _customValuesConfiguratio.GetCustomValueByName("TiwiloConfiguration");

            var accountSid = TwiloConfig.Values["AccountSid"];
            var authToken = TwiloConfig.Values["AuthToken"];
            var fromNumber = TwiloConfig.Values["FromNumber"];

            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
              new PhoneNumber("")); //Numero de la persona a la que se envia
            messageOptions.From = new PhoneNumber("");
            messageOptions.ContentSid = "HXb5b62575e6e4ff6129ad7c8efe1f983e";
            messageOptions.ContentVariables = "{\"1\":\"12 / 1\",\"2\":\"3pm\"}";

            var message = MessageResource.Create(messageOptions);
        }
    }
}
