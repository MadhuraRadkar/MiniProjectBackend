using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using MiniProject.Model;
using MiniProject.Services;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterationController : ControllerBase
    {
        private readonly IRegistrationService service;
        private readonly IConfiguration _config;
        public RegisterationController(IRegistrationService service,IConfiguration _config)
        {
            this.service = service;
            this._config = _config;
        }

        [HttpPost]
        [Route("Login")]

        public async Task<Hashtable> Post(Registration r)
        {
            Hashtable hashtable = new Hashtable();
            try
            {
                /* Registration u = await service.GetLogin(r);
                 string token = GenerateToken(u);
                 r.Token = token;
                 if (u != null)
                 {
                     return Ok(token);
                 }*/

                var list = await service.GetLogin(r);
                if (list != null)
                {
                    var token = GenerateToken(list);
                    hashtable.Add("Token",token);
                    hashtable.Add("Object",list);
                    return hashtable;
                    // return Ok(token);
                }
                
            }
            catch (Exception ex)
            {
           
               await Console.Out.WriteLineAsync(ex.Message);
            }
            return null;
        }

        [HttpPost]
        [Route("Registration")]

        public async Task<IActionResult> Post1([FromBody][Bind(include: "UserName,Password,Email,PhoneNumber")] Registration user)
        {
            try
            {
                var result = await service.Registration(user);
                if (result >= 1)
                    return StatusCode(StatusCodes.Status201Created);
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        private string GenerateToken(Registration reg)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,reg.UserName),
                new Claim(ClaimTypes.Role,reg.RoleId.ToString()),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}

