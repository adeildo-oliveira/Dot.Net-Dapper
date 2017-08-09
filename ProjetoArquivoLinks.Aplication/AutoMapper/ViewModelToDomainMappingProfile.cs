using System;
using System.Linq.Expressions;
using AutoMapper;
using ProjetoArquivoLinks.Aplication.ViewModels;
using ProjetoArquivoLinks.Domain.Entities;

namespace ProjetoArquivoLinks.Aplication.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMapping";

        protected override void Configure()
        {
            CreateMap<LinkViewModel, Link>();
            CreateMap<Expression<Func<LinkViewModel, bool>>, Expression<Func<Link, bool>>>();
        }
    }
}