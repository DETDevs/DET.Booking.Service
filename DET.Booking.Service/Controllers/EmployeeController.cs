using DET.Booking.BusinessLogic.Interfaces;
using DET.Booking.Models;
using Microsoft.AspNetCore.Mvc;

namespace DET.Booking.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpPost(Name = "GetEmployees")]
        public async Task<IActionResult> Get([FromBody] ResponseEmployee employee)
        {
            try
            {
                var resultado = await this._employee.GetEmployee(employee);

                if (!resultado.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Content);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost(Name = "SaveEmployees")]
        public async Task<IActionResult> Save([FromBody] ResponseEmployee employee)
        {
            try
            {
                var resultado = await this._employee.SaveEmployee(employee);

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
