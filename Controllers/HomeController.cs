using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using WebApplicationJWT.Models;

namespace WebApplicationJWT.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _config;
        public HomeController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet("AuthenticationTest")]
        public IActionResult Login(UserLogin model)
        {
            Console.WriteLine(model.toString());
            if (model.UserName == "Fabio" && model.Password == "CiaoMammaComeStai?IoStoBeneeTuchemidici?")
            {
                var token = GenerateToken(model);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(jwt);
            }
            return Unauthorized();
        }
        private JwtSecurityToken GenerateToken(UserLogin model)
        {
            var key = System.Text.Encoding.UTF8.GetBytes(_config["JWT:Key"]);
            var secret = new SymmetricSecurityKey(key);

            var jwtToken = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Role, model.Role),
                },
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["ExipireationTimeInMinutes"])),
                signingCredentials: new SigningCredentials(secret, SecurityAlgorithms.HmacSha256));
            return jwtToken;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
