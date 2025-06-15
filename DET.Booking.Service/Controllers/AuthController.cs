using DET.Booking.BusinessLogic.Interfaces;
using DET.Booking.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DET.Booking.Service.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class AuthController : Controller
    {
        private readonly IUser _user;

        public AuthController(IUser user)
        {
            _user = user;
        }

        [HttpPost(Name = "Register")]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                var resultado = await this._user.RegisterUser(user);

                if (!resultado.IsSuccess)
                    return StatusCode(StatusCodes.Status400BadRequest, resultado.Content);

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        
        [HttpPost(Name ="login")]
        public async Task<IActionResult> Login([FromBody] User request)
        {
            try
            {
                var result = await _user.LoginAsync(request);
                return result.IsSuccess ? Ok(result.Content) : Unauthorized(result.Message);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
