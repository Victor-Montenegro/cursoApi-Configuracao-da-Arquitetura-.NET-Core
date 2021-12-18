using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.UsuariosTeste
{
    public class RegistrarViewModelInputTESTE
    {
        [Required(ErrorMessage = "O campo login é necessário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo Email é necessário")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo senha é necessário")]
        public string Senha { get; set; }
    }
}
