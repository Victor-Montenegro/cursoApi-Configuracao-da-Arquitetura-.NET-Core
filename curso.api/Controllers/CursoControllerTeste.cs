using curso.api.Models.CursosTeste;
using curso.api.Models.UsuariosTeste;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v2/cursosTeste")]
    public class CursoControllerTeste : ControllerBase
    {

        // POST: cursosTeste/Post
        [HttpPost]
        [Route("Post")]
        [ValidacaoModelStateCustomizadoTESTE]
        public IActionResult Post(CursoViewModelnputTeste curso)
        {
            return Created("",curso);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var cursos = new List<CursoViewModelOutputTeste>();

            cursos.Add(new CursoViewModelOutputTeste()
            {
                Curso = "CC",
                Descricao = "TI",
                Login = "joao"
            });

            return Ok(cursos);
        }
    }
}
