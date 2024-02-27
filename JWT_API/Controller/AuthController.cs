using JWT.Models;
using JWT.Servise;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly GeneretTokenServies _generetToken;

        public AuthController(GeneretTokenServies  generetToken)
        {
            _generetToken = generetToken;
        }
        [HttpPost]

        public  IActionResult Login([FromBody]LoginDto loginDto)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = loginDto.Email,
                Password = loginDto.Password,
                Name = "husan"
            };
            var token = _generetToken.GetToken(user);
            return Ok(token);   
        }
    }
}
