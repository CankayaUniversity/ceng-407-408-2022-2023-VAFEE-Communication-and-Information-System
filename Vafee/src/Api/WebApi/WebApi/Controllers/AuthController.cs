using Api.Application.Token;
using Api.Domain.Models.Identity;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Domain.Models;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly VafeeContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(VafeeContext context, UserManager<User> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var user = loginUserDto switch
            {
                { Email: null } => await _userManager.FindByNameAsync(loginUserDto.Username),
                { Username: null } => await _userManager.FindByEmailAsync(loginUserDto.Email),
                _ => null
            };

            if (user == null)
            {
                // BadRequest olabilir
                // Kullanıcı db'de yok.
                return NotFound();
            }

            bool validUser = await _userManager.CheckPasswordAsync(user, loginUserDto.Password);

            if (!validUser)
            {
                // Kullanıcı db'de var, ama girdiği şifre yanlış. Uygun hata mesajını dönder.
                return BadRequest("Password is invalid.");
            }

            var userClaims = await GetUserClaims(user);

            var token = new Token()
            {
                AccessToken = GenerateAccessToken(userClaims),
                RefreshToken = GenerateRefreshToken()
            };

            return Ok(token);
        }

        //[HttpPost]
        //[Route("Register")]
        //public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        //{
        //    // aynı kullanıcı isminde veya emailde başka biri var mı
        //    // todo username ve email için ayrı ayrı hata mesajları yazılacak
        //    var userEmailExists = await _userManager.FindByEmailAsync(registerUserDto.Email);
        //    var userNameExists = await _userManager.FindByNameAsync(registerUserDto.Username);


        //    if (userEmailExists != null || userNameExists != null)
        //    {
        //        return BadRequest("User already exists.");
        //    }


        //    // todo Kullanıcı yok, oluştur, mapping daha sonra mapster ile yapılacak
        //    var student = new Student()
        //    {
        //        Email = registerUserDto.Email,
        //        FirstName = registerUserDto.FirstName,
        //        LastName = registerUserDto.Email,

        //    };

        //    return Ok();
        //}

        private async Task<IEnumerable<Claim>> GetUserClaims(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x));

            var userClaims = await _userManager.GetClaimsAsync(user);


            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("FullName", user.FullName),
                new Claim("UserId", user.Id)
            }.Union(userClaims).Union(roleClaims);


            return claims;
        }

        private string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["Jwt:ExpireInMinutes"])),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }

    public class RegisterUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class LoginUserDto
    {
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? Username { get; set; }
    }
}