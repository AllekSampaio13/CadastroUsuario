

namespace Cadastro.Domain.Models
{
    public class Usuario
    {
        public Usuario() { }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public bool Habilitacao { get; private set; }



        public Usuario(string nome, string cpf, string telefone, string email,
            bool habilitacao)
        {
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Email = email;
            Habilitacao = true;
        }

        public void Atualizar(string nome, string telefone, 
            string email, bool habilitacao)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Habilitacao= habilitacao;
        }
        

    }
}

