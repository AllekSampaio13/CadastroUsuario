using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ICadastroAppService _cadastroAppService;

    public UsuarioController(ICadastroAppService cadastroAppService)
    {
        _cadastroAppService = cadastroAppService;
    }

    [HttpGet]
    public async Task<IActionResult> ListarUsuario()
    {
        var usuario = await _cadastroAppService.ListarUsuario();
        if (usuario == null) return NotFound("Nenhum usuário encontrado");
        return Ok(usuario);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> UsuarioId(int id)
    {
        var usuario = await _cadastroAppService.UsuarioId(id);
        if (usuario == null) return NotFound("Nenhum usuário encontrado");
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarUsuario([FromBody] NovoUsuarioViewModel vm)
    {
        var result = await _cadastroAppService.CadastrarUsuario(vm);
        if (result == null) return BadRequest("Não foi possível cadastrar o usuário");
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarUsuario([FromBody] AtualizarUsuarioViewModel vm)
    {
        var result = await _cadastroAppService.AtualizarUsuario(vm);
        if (result == null) return BadRequest("Não foi possível atualizar o usuário");
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeletarUsuario(int id)
    {
        var result = await _cadastroAppService.DeletarUsuario(id);
        if (!result) return BadRequest($"Não foi possível excluir o usuário {id}");
        if (result) return Ok();
        return NotFound();
    }



}
