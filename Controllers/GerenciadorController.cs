using ApiBalada.Models;
using ApiBalada.ViewModels;
using Loja.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBalada.Controllers;

[ApiController]
public class GerenciadorController : ControllerBase
{
    private readonly BaladaDbContext _baladaRepository;

    public GerenciadorController(BaladaDbContext balada)
    {
        _baladaRepository = balada;
    }

    [Authorize(Roles = "porteiro, adm")]
    [HttpPost]
    [Route("comanda")]
    public async Task<IActionResult> Comanda([FromBody] ComandaViewModel model)
    {
        try
        {
            var comanda = await _baladaRepository.Comandas.Where(x => x.Cmd == model.Comanda).FirstOrDefaultAsync();

            if(comanda.Status != false && comanda.Data != DateTime.Now)
                return BadRequest(new ResultViewModel<Comanda>("Comanda já foi ultilizada Hoje."));

            var ativaComanda = new Comanda 
            { 
                Cmd = model.Comanda, 
                Status = true, 
                Data = DateTime.Now 
            };

            await _baladaRepository.Comandas.AddAsync(ativaComanda);
            await _baladaRepository.SaveChangesAsync();

            return Ok(new ResultViewModel<Comanda>(ativaComanda));
        }
        catch
        {
            return BadRequest(new ResultViewModel<Comanda>("Deu Ruim"));
        }
    }

    [Authorize(Roles = "garcon")]
    [HttpPost]
    [Route("comanda/pedidos")]
    public async Task<IActionResult> ComandaPedido([FromBody] ComandaPedidoViewModel model)
    {
        try
        {
            var comanda = await _baladaRepository.Comandas.FindAsync(model.id);

            if(comanda.Status == false)
                return BadRequest(new ResultViewModel<Pedido>("Comanda não Ativada"));
            
            var pedido = new Pedido();
            foreach(var cm in model.Comanda)
            {
                pedido.CodigoProduto = cm.Codigo;
                pedido.QuantidadeDoPedido = cm.QtPedido;
                pedido.ComandaId = comanda.Id;
                _baladaRepository.Pedidos.AddAsync(pedido);
            }
           
            await _baladaRepository.SaveChangesAsync();
            return Ok(new ResultViewModel<Pedido>(pedido));
        }
        catch
        {
            return BadRequest(new ResultViewModel<Pedido>("Deu Ruim"));
        }
    }

    [Authorize(Roles = "caixa, adm")]
    [HttpGet]
    [Route("comanda/historico")]
    public async Task<IActionResult> Get([FromBody] ComandaHistoricoViewModel model)
    {
        try
        {
            var comanda = model?.Data != null || model?.Id != null ? await _baladaRepository.Pedidos.Where(x => x.Data == model.Data || x.Id == model.Id).ToListAsync() : await _baladaRepository.Pedidos.ToListAsync();

            if(comanda == null)
                return BadRequest(new ResultViewModel<Pedido>("Comanda não existe"));

            return Ok(new ResultViewModel<List<Pedido>>(comanda));
        }
        catch
        {
            return BadRequest(new ResultViewModel<Pedido>("Deu Ruim"));
        }
    }

}