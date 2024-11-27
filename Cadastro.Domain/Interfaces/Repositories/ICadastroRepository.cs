using Cadastro.Domain.Models;


namespace Cadastro.Domain.Interfaces.Repositories;

public interface ICadastroRepository : IBaseRepository<Usuario>
{
    Task<IEnumerable<Usuario>> ListarUsuario();
    Task<Usuario> UsuarioId(int id);
    Task CadastrarUsuario(Usuario usuario);
    Task AtualizarUsuario(Usuario usuario);
    Task DeletarUsuario(Usuario usuario);
}
