using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OrangesAndChocolate.DTO;
using OrangesAndChocolate.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrangesAndChocolate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<SiteUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;


        public AuthController(UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        //route for seeding roles to DB
        [HttpPost("seed-role")]
        public async Task<IActionResult> SeedRoles()
        {
            bool isAdminRole = await _roleManager.RoleExistsAsync(StaticUserRoles.Admin);
            bool isUserRole = await _roleManager.RoleExistsAsync(StaticUserRoles.User);
            bool isGuestRole = await _roleManager.RoleExistsAsync(StaticUserRoles.Guest);

            if (isAdminRole && isUserRole && isGuestRole) 
            {
                return Ok("Already done");
            }


            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.Admin));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.User));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.Guest));

            return Ok("Seeding done");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO rDTO)
        {
            //I put email should be unique
            var userExists = await _userManager.FindByNameAsync(rDTO.Username);
            if (userExists != null)
            {
                return BadRequest("Username already exists.");
            }
            var tempUser = new SiteUser()
            {
                Email = rDTO.Email,
                UserName = rDTO.Username,

            };

            var createUserResult = await _userManager.CreateAsync(tempUser, rDTO.Password);
            if (!createUserResult.Succeeded) 
            {
                var errorMsg = "Can't make user ";
                foreach (var error in createUserResult.Errors)
                {
                    errorMsg += " - " + error.Description;
                }
                BadRequest(errorMsg);
            }

            await _userManager.AddToRoleAsync(tempUser, StaticUserRoles.User);
            return Ok("User created succesfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInDTO lDTO)
        {
            var tempUser = await _userManager.FindByNameAsync(lDTO.Username);
            if (tempUser == null)
            {
                return Unauthorized("Bad username.");
            }
            var checkPass = await _userManager.CheckPasswordAsync(tempUser, lDTO.Password);
            if (!checkPass)
            {
                return Unauthorized("Bad password.");
            }

            var userRoles = await _userManager.GetRolesAsync(tempUser);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, tempUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var claim in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, claim));
            }

            var token = GenerateNewJsonWebToken(authClaims);

            return Ok(token);
        }

        private string GenerateNewJsonWebToken(List<Claim> claims)
        {
            var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenO = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(2),
                claims: claims,
                signingCredentials: new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256)
                );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenO);

            return token;
        }
    }
}
