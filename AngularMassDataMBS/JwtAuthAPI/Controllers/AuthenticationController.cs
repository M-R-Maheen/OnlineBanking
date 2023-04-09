using JwtAuthAPI.Models;
using JwtAuthAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthAPI.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateSercice;

        public AuthenticationController(IAuthenticateService authenticateSercice)
        {
            _authenticateSercice = authenticateSercice;
        }

        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            var user = _authenticateSercice.Authenticate(model.UserName, model.Password);
            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(user);
            }
        }
    }
}
