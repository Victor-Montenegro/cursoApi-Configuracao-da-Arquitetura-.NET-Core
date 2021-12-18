using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.CursosTeste
{
    public class CursoViewModelnputTeste
    {
        [Required(ErrorMessage ="Campo Nome é necessário")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Campo Descricao é necessário")]
        public string Descricao { get; set; }
    }
}
