using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Models;
using Cadastro.Infra.Data.EF;
using Cadastro.Infra.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;


namespace Cadastro.Infra.Data.Repositories
{
    public class CadastroRepository : BaseRepository<Usuario>, ICadastroRepository
    {
        private readonly CadastroContext _context;

        public CadastroRepository(CadastroContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ListarUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> UsuarioId(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task CadastrarUsuario(Usuario usuario)
        {
            await _context.AddAsync(usuario);
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            await Task.FromResult(_context.Update(usuario));
        }

        public async Task DeletarUsuario(Usuario usuario)
        {
            await Task.FromResult(_context.Remove(usuario));
        }



    }
}
