﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.UsuariosTeste
{
    public class LoginViewModelInputTESTE
    {
        [Required(ErrorMessage ="Campo Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório")]
        public string Senha { get; set; }
    }
}
