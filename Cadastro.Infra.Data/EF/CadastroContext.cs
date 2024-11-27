using Cadastro.Domain.Interfaces;
using Cadastro.Domain.Models;
using Cadastro.Infra.Data.EF.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;


namespace Cadastro.Infra.Data.EF
{
    public class CadastroContext : DbContext, IUnitOfWork
    {
        public CadastroContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            CriarBancoCasoNaoExista();
        }

        private void CriarBancoCasoNaoExista()
        {
            if (!(Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
        }

        public DbSet<Usuario> Usuarios { get; set; }


    }
}
