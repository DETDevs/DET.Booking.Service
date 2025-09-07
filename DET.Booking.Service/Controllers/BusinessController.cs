using DET.Booking.BusinessLogic.Interfaces;
using DET.Booking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DET.Booking.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BusinessController : Controller
    {
        private readonly IBusiness _business;


        public BusinessController(IBusiness business)
        {
            _business = business;
        }

        [HttpPost(Name = "GetBusiness")]
        public async Task<IActionResult> Get([FromBody] Business business) 
        {
            try
            {
                var resultado = await this._business.GetBusiness(business);

                if (!resultado.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Content);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost(Name = "SaveBusiness")]
        public async Task<IActionResult> Save([FromBody] Business business)
        {
            try
            {
                var resultado = await this._business.SaveBusiness(business);

                if (!resultado.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Content);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost(Name = "SaveSettings")]
        public async Task<IActionResult> SaveSettings([FromBody] BusinessSetting<Object> request)
        {
            try
            {
                var resultado = await this._business.SaveBusinessSettings(request);

                if (!resultado.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Content);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{businessId}/{key}")]
        public async Task<IActionResult> GetConfig(int businessId, string key)
        {
            object config;

            if (key.StartsWith("Input"))
            {
                config = await _business.ObtenerConfiguracion<FormInput>(businessId, key);
            }
            else if (key.StartsWith("Label"))
            {
                config = await _business.ObtenerConfiguracion<FormLabel>(businessId, key);
            }
            else if (key.StartsWith("Boton"))
            {
                config = await _business.ObtenerConfiguracion<FormButton>(businessId, key);
            }
            else if (key.StartsWith("Formulario"))
            {
                config = await _business.ObtenerConfiguracion<FormConfig>(businessId, key);
            }
            else
            {
                return BadRequest(new { message = "Tipo de configuración no reconocido" });
            }

            return Ok(config);
        }
    }
}
