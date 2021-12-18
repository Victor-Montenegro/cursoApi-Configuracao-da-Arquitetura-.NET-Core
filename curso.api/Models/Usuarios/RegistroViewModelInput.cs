using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.Usuarios
{
    public class RegistroViewModelInput
    {
        [Required(ErrorMessage = "O login é Obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O Email é Obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Senha é Obrigatório")]
        public string Senha { get; set; }
    }
}
