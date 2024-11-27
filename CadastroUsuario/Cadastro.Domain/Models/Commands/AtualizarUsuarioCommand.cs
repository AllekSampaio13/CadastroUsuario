
namespace Cadastro.Domain.Models.Commands;

public class AtualizarUsuarioCommand
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public bool Habilitacao { get; set; }
}
