using Cadastro.Application.ViewModel;


namespace Cadastro.Application.Services.Interfaces;

public interface ICadastroAppService
{
    Task<IEnumerable<UsuarioViewModel>> ListarUsuario();
    Task<UsuarioViewModel> UsuarioId(int id);
    Task<UsuarioViewModel> CadastrarUsuario(NovoUsuarioViewModel novoUsuarioViewModel);
    Task<UsuarioViewModel> AtualizarUsuario(AtualizarUsuarioViewModel atualizarusuarioViewModel);
    Task<bool> DeletarUsuario(int id);
}
