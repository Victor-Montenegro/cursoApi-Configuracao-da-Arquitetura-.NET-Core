using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models
{
    public class ValidaCampoViewModelOutputTeste
    {
        public IEnumerable<string> Erros { get; set; }

        public ValidaCampoViewModelOutputTeste(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
