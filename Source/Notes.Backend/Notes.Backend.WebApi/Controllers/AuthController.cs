using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Notes.Backend.Application.Interfaces;
using Notes.Backend.Domain.Models;
using Notes.Backend.WebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Notes.Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly static User user = new();
        private readonly IConfiguration _configuration;
        private readonly INotesDbContext _dbContext;

        public AuthController(IConfiguration configuration, INotesDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Id = Guid.NewGuid();
            user.Login = request.Login;
            user.PasswordHash = passwordHash;

            if (_dbContext.Users.Select(u => u.Login).Contains(user.Login))
            {
                return BadRequest("Such a user already exists.");
            }

            CancellationToken cancellationToken = CancellationToken.None;
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Ok(user);
        }

        [HttpPost("Login")]
        public ActionResult<User> Login(UserDTO request)
        {
            var user  = _dbContext.Users.FirstOrDefault(u => u.Login == request.Login);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Login)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
