using Microsoft.AspNetCore.Mvc;
using MiniERP.API.Class;
using MiniERP.API.DTO;
using MiniERP.API.Services;

namespace MiniERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            PasswordService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.UsuarioID = 1; //TODO: Inserir de forma incremental.
            user.CompleteName = request.CompleteName;
            user.Username = request.UserName;
            user.PhoneNumber = request.PhoneNumber;
            user.Email = request.Email;
            user.CPF = request.CPF;

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);

        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto request)
        {
            if (user.Username != request.Username)
            {
                return BadRequest("User not Found");
            }

            if (!PasswordService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }

            string token = new TokenService(_configuration).CreateToken(user);
            return Ok(token);
        }
    }
}
