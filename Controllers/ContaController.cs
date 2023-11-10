using ApiBalada.Models;
using ApiBalada.Services;
using ApiBalada.ViewModels;
using Loja.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBalada.Controllers;

[ApiController]
public class ContaController : ControllerBase
{
    private readonly BaladaDbContext _baladaRepository;
    private readonly TokenService _tokenService;

    public ContaController(BaladaDbContext balada,
                           TokenService tokenService)
    {
        _baladaRepository = balada;
        _tokenService = tokenService;
    }

    [HttpGet]
    [Route("conta")]
    public async Task<IActionResult> Get([FromBody] ContaViewModel model)
    {
        try
        {
            var conta = await _baladaRepository.Funcionarios.FirstOrDefaultAsync(x => x.Identificador == model.Identificador && x.Senha == Settings.GenerateHash(model.Senha));

            if (conta == null)
                return StatusCode(204,new ResultViewModel<List<Funcionario>>("Senha ou Indentificador errada"));
            
            var token = _tokenService.CreateToken(conta);

            return Ok(new ResultViewModel<Funcionario>(token));
        }
        catch
        {
            return BadRequest(new ResultViewModel<Funcionario>("Deu Ruim"));
        }
    }

    [Authorize(Roles = "adm")]
    [HttpPost]
    [Route("conta/Cadastro")]
    public async Task<IActionResult> Post([FromBody] CadastroViewlModel model)
    {
        try
        {
            var conta = _baladaRepository.Funcionarios.FindAsync(model.Identificador);

            if (conta != null)
                return StatusCode(204,new ResultViewModel<Funcionario>("Já Existe esse Identificador"));
            
            var cadastro = new Funcionario 
            {
                Identificador = model.Identificador,
                Nome = model.Nome,
                Role = model.Role,
                Senha = Settings.GenerateHash(model.Senha)
            };

            await _baladaRepository.Funcionarios.AddAsync(cadastro);
            await _baladaRepository.SaveChangesAsync();

            return Ok(new ResultViewModel<Funcionario>(cadastro));
        }
        catch
        {
            return BadRequest(new ResultViewModel<Funcionario>("Deu Ruim"));
        }
    }
}