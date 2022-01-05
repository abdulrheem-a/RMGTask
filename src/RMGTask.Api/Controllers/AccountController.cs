using RMGTask.Api.Requests;
using RMGTask.Core.Configuration;
using RMGTask.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RMGTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly RMGTaskSettings _RMGTaskSettings;
        private readonly SignInManager<RMGTaskUser> _signInManager;
        private readonly UserManager<RMGTaskUser> _userManager;

        public AccountController(SignInManager<RMGTaskUser> signInManager,
          UserManager<RMGTaskUser> userManager,
          IOptions<RMGTaskSettings> options)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _RMGTaskSettings = options.Value;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody]LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                    // Create the token
                    var claims = new[]
                    {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };

                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_RMGTaskSettings.Tokens.Key));
                    var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                      _RMGTaskSettings.Tokens.Issuer,
                      _RMGTaskSettings.Tokens.Audience,
                      claims,
                      expires: DateTime.Now.AddMinutes(30),
                      signingCredentials: signingCredentials);

                    var results = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    };

                    return Created("", results);
                }
            }

            return Unauthorized();
        }
    }
}
