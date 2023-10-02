using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControleFacil.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected long ObterIdUsuarioLogado()
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _ = long.TryParse(id, out long idUsuario);

            return idUsuario;
        }
    }
}