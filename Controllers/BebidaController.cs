using ApiBalada.Models;
using ApiBalada.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBalada.Controllers;

[ApiController]
public class BebidaController : ControllerBase 
{
    [Authorize(Roles = "adm")]
    [HttpGet]
    [Route("comanda/historico")]
    public async Task<IActionResult> Get([FromBody] BebidaViewlModel model)
    {
        try
        {
            var comanda = new Bebida
            {
                CodigoProduto = model.CodigoProduto,
                Valor = model.Valor
            };

            if(comanda == null)
                return BadRequest(new ResultViewModel<Bebida>("Comanda não existe"));

            return Ok(new ResultViewModel<Bebida>(comanda));
        }
        catch
        {
            return BadRequest(new ResultViewModel<Bebida>("Deu Ruim"));
        }
    }
}