using MeetupApi.BLL.DTO;
using MeetupApi.BLL.Interfaces;
using MeetupApi.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeetupApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly string _secretKey;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService 
                ?? throw new ArgumentNullException();
            _secretKey = configuration["Jwt:SecretKey"];
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserDTO userDTO)
        {
           
            var user = await _userService.Register(userDTO);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"{userDTO.Email} could not be register.");
            }

            return StatusCode(StatusCodes.Status200OK, $"A new user has been created: {userDTO.Email}");
           
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            var result = await _userService.Authenticate(userDTO.Email, userDTO.Password);

            if (result == true)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "WebEvent",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized(new { error = "Invalid username or password" });
            }
        }
    }
}
