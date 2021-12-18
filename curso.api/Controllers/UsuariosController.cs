using curso.api.Filters;
using curso.api.Infraestruture.Data;
using curso.api.Models;
using curso.api.Models.Usuarios;
using curso.api.Platform.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/v1/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //POST: Usuarios/Logar
        [HttpPost]
        [Route("Logar")]
        [ValidacaoModelStateCustimizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            // REALIZANDO SIMULACAO DE CONSULTA DE BANCO
            UsuarioViewModelOutput usuario = new UsuarioViewModelOutput()
            {
                Codigo = 1,
                Login = "Joao victor",
                Email = "jvc@jvc.com",
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

            return Ok(new{Token = token, Usuario = usuario});
        }

        // POST: /usuarios/Register
        [HttpPost]
        [Route("Registrar")]
        [ValidacaoModelStateCustimizado]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextDb>();
            optionsBuilder.UseSqlServer("Server=(localdb)mssqllocaldb;Database=CURSO;Integrated Security=true");

            ContextDb context = new ContextDb(optionsBuilder.Options);

            var migrationPending = context.Database.GetPendingMigrations();

            if (migrationPending.Count() > 0)
                context.Database.Migrate();

            var usuario = new Usuario()
            {
                Login = registroViewModelInput.Login,
                Senha = registroViewModelInput.Senha,
                Email = registroViewModelInput.Email
            };

            context.Usuario.Add(usuario);
            context.SaveChanges();

            return Created("", registroViewModelInput);
        }
    }
}
