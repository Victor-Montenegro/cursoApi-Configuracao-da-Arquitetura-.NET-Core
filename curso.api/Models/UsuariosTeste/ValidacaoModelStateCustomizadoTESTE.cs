using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.UsuariosTeste
{
    public class ValidacaoModelStateCustomizadoTESTE : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var validaCampoViewModelTESTE = new ValidaCampoViewModelTESTE(context.ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage));

                context.Result = new BadRequestObjectResult(validaCampoViewModelTESTE);
            }
        }
    }
}
