using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.UsuariosTeste
{
    public class ValidaCampoViewModelTESTE
    {
        public IEnumerable<string> Erros { get; private set; }

        public ValidaCampoViewModelTESTE(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
