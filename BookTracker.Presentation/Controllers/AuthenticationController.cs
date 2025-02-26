using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BookTracker.Presentation.Controllers
{
	[ApiController]
	[Route("authentication")]
	public class AuthenticationController : ControllerBase
	{
		private IConfiguration configuration { get; }

		public AuthenticationController(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		[HttpPost]
		[Route("login")]
		public IActionResult Login([FromBody] string username)
		{
			var jwtKey = configuration["JWT:Key"];
			var jwtIssuer = configuration["JWT:Issuer"];
			var jwtAudience = configuration["JWT:Audience"];

			if (jwtKey == null || jwtIssuer == null || jwtAudience == null)
			{
				return StatusCode(500);
			}

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			if (username == "user")
			{
				var claims = new[]{
			new Claim(ClaimTypes.Role, "user")
		};

				var Sectoken = new JwtSecurityToken(
				  jwtIssuer, jwtAudience, claims,
				  expires: DateTime.Now.AddMinutes(60),
				  signingCredentials: credentials);

				var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

				return Ok(token);
			}
			else if (username == "admin")
			{
				var claims = new[]{
			new Claim(ClaimTypes.Role, "admin")
		};

				var Sectoken = new JwtSecurityToken(
				  jwtIssuer, jwtAudience, claims,
				  expires: DateTime.Now.AddMinutes(60),
				  signingCredentials: credentials);

				var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

				return Ok(token);
			}
			else
			{
				return BadRequest("Invalid Username");
			}
		}
	}
}
