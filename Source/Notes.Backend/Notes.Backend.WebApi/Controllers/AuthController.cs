using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var user = new User
            {
                Id = Guid.NewGuid(),
                Login = request.Login,
                PasswordHash = passwordHash
            };

            if (_dbContext.Users.Select(u => u.Login).Contains(user.Login))
            {
                return BadRequest("Such a user already exists.");
            }

            CancellationToken cancellationToken = default;
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(UserDTO request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == request.Login);

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

            string jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
