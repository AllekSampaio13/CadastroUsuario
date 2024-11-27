using AutoMapper;
using Cadastro.Application.ViewModel;
using Cadastro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Mapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
