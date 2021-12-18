using curso.api.Models.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize] 
    public class CursoController : ControllerBase
    {

        [HttpPost]
        [Route("Cursos")]
        public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
        {
            //var codigo = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            return Created("",cursoViewModelInput);
        }

        [HttpGet]
        [Route("CursosList")]
        public async Task<IActionResult> Get(CursoViewModelInput cursoViewModelInput)
        {
            var cursos = new List<CursoViewModelOutput>();

            //var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            cursos.Add(new CursoViewModelOutput()
            {
                //Login = codigoUsuario.ToString(),
                Descricao = "teste",
                Nome = "teste"
            });

            return Ok(cursos);
        }
    }
}

