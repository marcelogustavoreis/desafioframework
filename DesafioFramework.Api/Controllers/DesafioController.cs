using DesafioFramework.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DesafioFramework.Api.Controllers
{
    [ApiController]
    [Route("api/desafio")]
    public class DesafioController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult Index([Required(ErrorMessage = "Número de entrada é obrigatório"),Range(2, int.MaxValue, ErrorMessage = "Número de entrada deve ser maior que 1")] int numeroEntrada)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var desafio = new Desafio(numeroEntrada);
            return Ok(desafio);
        }
    }
}
