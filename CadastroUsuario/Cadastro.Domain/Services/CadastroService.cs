using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Commands;


namespace Cadastro.Domain.Services;

public class CadastroService : ICadastroService
{
    private readonly ICadastroRepository _cadastroRepository;

    public CadastroService(ICadastroRepository cadastroRepository)
    {
        _cadastroRepository = cadastroRepository;
    }

    public async Task<IEnumerable<Usuario>> ListarUsuario()
    {
        return await _cadastroRepository.ListarUsuario();
    }

    public async Task<Usuario> UsuarioId(int id)
    {
        return await _cadastroRepository.Get(x => x.Id == id);
    }

    public async Task<Usuario> CadastrarUsuario(Usuario usuario)
    {
        await _cadastroRepository.CadastrarUsuario(usuario);

        await _cadastroRepository.UnitOfWork.SaveChangesAsync();

        return usuario;
    }

    public async Task<Usuario> AtualizarUsuario(AtualizarUsuarioCommand command)
    {
        var usuario = await _cadastroRepository.Get(x => x.Id == command.Id);
        if (usuario == null) return null;

        usuario.Atualizar(command.Nome,
            command.Telefone,
            command.Email,
            command.Habilitacao);

        await _cadastroRepository.AtualizarUsuario(usuario);
        await _cadastroRepository.UnitOfWork.SaveChangesAsync();
        return usuario;

    }

    public async Task<bool> DeletarUsuario(int id)
    {
        var usuario = await _cadastroRepository.Get(x =>x.Id == id);
        if (usuario == null) return false;

        await _cadastroRepository.DeletarUsuario(usuario);
        await _cadastroRepository.UnitOfWork.SaveChangesAsync();

        return true;

    }


}
