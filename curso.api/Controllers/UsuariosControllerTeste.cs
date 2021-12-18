using curso.api.Models.Usuarios;
using curso.api.Models.UsuariosTeste;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [ApiController]
    [Route("api/v2/UsuariosTeste")]
    public class UsuariosControllerTeste : ControllerBase
    {
        // POST : usuariosTeste/logar    
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizadoTESTE]
        public IActionResult Logar(LoginViewModelInputTESTE login)
        {
            UsuarioViewModelOutputTeste usuario = new UsuarioViewModelOutputTeste()
            {
                Codigo = 1,
                Email = "jvc@jvc",
                Login = "joao"
            };

            var secret = Encoding.ASCII.GetBytes("M@op1i34-09_[lç12]~ç12]30-ISK33C=2=-iqwjd");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Login.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return Ok(new { Token = token, Usuario = usuario});
        }

        //POST : /usuariosTeste/Registrar
        [HttpPost]
        [Route("registrar")]
        public IActionResult Registrar(RegistrarViewModelInputTESTE registrar)
        {
            return Created("",registrar);
        }
    }
}
