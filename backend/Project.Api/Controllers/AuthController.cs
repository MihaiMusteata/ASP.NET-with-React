using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project.Domain.Entities.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using MediatR;
using Project.Api.Queries;
using Project.Api.Filters;
using System.Diagnostics;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace Project.Api.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class AuthController : ControllerBase
     {
          public readonly IConfiguration _configuration;
          private readonly IMediator _mediator;

          public AuthController(IConfiguration configuration, IMediator mediator)
          {
               _configuration = configuration;
               _mediator = mediator;
          }

          [HttpPost("signup")]
          public async Task<ActionResult> Signup(UserSignup model)
          {
               var query = new SignupQuery(model, HttpContext);
               var result = await _mediator.Send(query);

               if (result.Status)
               {
                    return Ok(result);
               }
               else
               {
                    return BadRequest(result);
               }
          }

          [HttpPost("login")]
          public async Task<ActionResult> Login(UserLogin model)
          {
               var query = new LoginQuery(model, HttpContext);
               var result = await _mediator.Send(query);
               if (result.Status)
               {
                    Debug.WriteLine("Login success  : " + result.StatusMsg);
                    return Ok(result);
               }
               else
               {
                    Debug.WriteLine("Login failed  : " + result.StatusMsg);
                    return BadRequest(result);
               }
          }

          [HttpPost("logout")]
          public async Task<ActionResult> Logout(int userId)
          {
               string cookieName = "X-Key";

               // Creează o instanță a opțiunilor cookie-ului, fără a seta nicio proprietate
               var cookieOptions = new CookieOptions();

               // Setează data de expirare a cookie-ului în trecut pentru a-l invalida
               cookieOptions.Expires = DateTime.Now.AddDays(-1);

               // Șterge cookie-ul
               Response.Cookies.Append(cookieName, "", cookieOptions);
               var query = new LogoutQuery(HttpContext, userId);
               try
               {
                    var result = await _mediator.Send(query);
                    return Ok("Logout successful");
               }
               catch (Exception ex)
               {
                    return StatusCode(500, $"Error during logout: {ex.Message}");
               }
          }

          [HttpGet("profile")]
          public async Task<ActionResult> Profile()
          {
               var query = new ProfileQuery(HttpContext);
               var result = await _mediator.Send(query);
               if (result != null)
               {
                    return Ok(result);
               }
               else
               {
                    return BadRequest(result);
               }
          }


          //[HttpPost("register")]
          //public async Task<ActionResult<User>> Register(UserDto request)
          //{
          //     CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

          //     user.Username = request.Username;
          //     user.PasswordHash = passwordHash;
          //     user.PasswordSalt = passwordSalt;

          //     return Ok(user);

          //}

          //public async Task<ActionResult<User>> Login(UserDto request)
          //{
          //     if (user.Username != request.Username)
          //     {
          //          return BadRequest("Invalid username");
          //     }

          //     if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
          //     {
          //          return BadRequest("Invalid password");
          //     }

          //     string token = CreateToken(user);

          //     return Ok(token);
          //}

          //private string CreateToken(User user)
          //{
          //     List<Claim> claims = new List<Claim>
          //     {
          //          new Claim(ClaimTypes.Name, user.Username)
          //     };

          //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

          //     var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

          //     var token = new JwtSecurityToken(
          //          claims: claims,
          //          expires: DateTime.Now.AddDays(1),
          //          signingCredentials: cred
          //     );

          //     var jwt = new JwtSecurityTokenHandler().WriteToken(token);

          //     return jwt;
          //}

          //private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
          //{
          //     using (var hmac = new HMACSHA512())
          //     {
          //          passwordSalt = hmac.Key;
          //          passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
          //     }
          //}

          //private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
          //{
          //     using (var hmac = new HMACSHA512(passwordSalt))
          //     {
          //          var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
          //          return computedHash.SequenceEqual(passwordHash);
          //     }
          //     return true;
          //}
     }
}
