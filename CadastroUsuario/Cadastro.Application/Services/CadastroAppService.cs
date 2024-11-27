using AutoMapper;
using Cadastro.Application.Services.Interfaces;
using Cadastro.Application.ViewModel;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.Application.Services;

public class CadastroAppService : ICadastroAppService
{
    private readonly ICadastroService _cadastroService;
    private readonly IMapper _mapper;

    public CadastroAppService(ICadastroService cadastroService, IMapper mapper)
    {
        _cadastroService = cadastroService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UsuarioViewModel>> ListarUsuario()
    {
        var usuario = await _cadastroService.ListarUsuario();
        return _mapper.Map<IEnumerable<UsuarioViewModel>>(usuario);
    }

    public async Task<UsuarioViewModel> UsuarioId(int id)
    {
        var usuario = await _cadastroService.UsuarioId(id);
        return _mapper.Map<UsuarioViewModel>(usuario);
    }

    public async Task<UsuarioViewModel> CadastrarUsuario(NovoUsuarioViewModel novoUsuarioViewModel)
    {
        var novoUsuario = new Usuario(novoUsuarioViewModel.Nome,
            novoUsuarioViewModel.CPF,
            novoUsuarioViewModel.Telefone,
            novoUsuarioViewModel.Email,
            novoUsuarioViewModel.Habilitacao);
        var usuarioCadastrado = await _cadastroService.CadastrarUsuario(novoUsuario);
        return _mapper.Map<UsuarioViewModel>(usuarioCadastrado);

    }

    public async Task<UsuarioViewModel> AtualizarUsuario(AtualizarUsuarioViewModel atualizarUsuarioViewModel)
    {
        var command = new AtualizarUsuarioCommand
        {
            Id = atualizarUsuarioViewModel.Id,
            Nome = atualizarUsuarioViewModel.Nome,
            Telefone = atualizarUsuarioViewModel.Telefone,
            Email = atualizarUsuarioViewModel.Email,
            Habilitacao = atualizarUsuarioViewModel.Habilitacao,

        };
        var usuarioAtualizado = await _cadastroService.AtualizarUsuario(command);
        return _mapper.Map<UsuarioViewModel>(usuarioAtualizado);


    }

    public async Task<bool> DeletarUsuario(int id)
    {
        return await _cadastroService.DeletarUsuario(id);
    }



}
