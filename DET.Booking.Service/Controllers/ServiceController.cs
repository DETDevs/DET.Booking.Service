using DET.Booking.BusinessLogic.Interfaces;
using DET.Booking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DET.Booking.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ServiceController : Controller
    {
        private readonly IService _service;

        public ServiceController(IService servicio)
        {
            _service = servicio;
        }

        [HttpPost(Name = "GetServices")]
        public async Task<IActionResult> GetServices([FromBody] Models.ServiceResponse service)
        {
            try
            {
                var resultado = await this._service.GetAsyncServices(service);

                if (!resultado.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Content);

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetServiceSchedule")]
        public async Task<IActionResult> GetServiceSchedule(int employeeID, DateTime fecha)
        {
            try
            {
                var resultado = await this._service.GetServiceSchedule(employeeID, fecha);

                if (!resultado.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Content);

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
