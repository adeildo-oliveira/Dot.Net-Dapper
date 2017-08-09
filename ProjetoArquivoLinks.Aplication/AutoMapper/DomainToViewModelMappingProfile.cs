using System;
using System.Linq.Expressions;
using AutoMapper;
using ProjetoArquivoLinks.Aplication.ViewModels;
using ProjetoArquivoLinks.Domain.Entities;

namespace ProjetoArquivoLinks.Aplication.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToApplicationMapping";

        protected override void Configure()
        {
            CreateMap<Link, LinkViewModel>();
            CreateMap<Expression<Func<Link, bool>>, Expression<Func<LinkViewModel, bool>>>();
        }
    }
}