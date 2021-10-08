using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestWithASP_NET5.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RestWithASP_NET5.Controllers
{
    public class SegurancaController : Controller
    {
        private IConfiguration _config;
        public SegurancaController(IConfiguration Configuration)
        {
            _config = Configuration;
        }

        private bool ValidarUsuario(TokenLogin login)
        {
            if (login.Usuario == "ioasys" && login.Senha == "1234")
                return true;

            else
                return false;
 
        }

        private string GerarToken()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: expiry,
                signingCredentials: credentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] TokenLogin login)
        {
            bool resultado = ValidarUsuario(login);
            if (resultado)
            {
                var tokenString = GerarToken();
                return Ok(new TokenRetorno { Token = tokenString, DataTokenGerado = DateTime.Now });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
