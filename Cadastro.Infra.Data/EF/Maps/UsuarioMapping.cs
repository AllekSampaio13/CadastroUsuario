using Cadastro.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infra.Data.EF.Maps
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.CPF)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.Telefone)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.Habilitacao)
              .IsRequired();


        }


    }
}
