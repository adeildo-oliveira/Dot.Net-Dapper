using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using ProjetoArquivoLinks.Aplication.Interfaces;
using ProjetoArquivoLinks.Aplication.ViewModels;
using ProjetoArquivoLinks.Domain.Entities;
using ProjetoArquivoLinks.Domain.Interfaces.Services;
using ProjetoArquivoLinks.Infra.Data.Context;

namespace ProjetoArquivoLinks.Aplication
{
    public class LinksAppService : AppServiceBase<ProjetoArquivoLinksContext>, ILinkAppService
    {
        private readonly ILinkService _linkService;

        public LinksAppService(ILinkService linkService)
        {
            _linkService = linkService;
        }
        
        public void Add(LinkViewModel linkViewModel)
        {
            var link = Mapper.Map<LinkViewModel, Link>(linkViewModel);

            BeginTransaction();
            _linkService.Add(link);
            Commit();
        }

        public LinkViewModel GetById(Guid id)
        {
            return Mapper.Map<Link, LinkViewModel>(_linkService.GetById(id));
        }

        public IEnumerable<LinkViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Link>, IEnumerable<LinkViewModel>>(_linkService.GetAll());
        }

        public void Update(LinkViewModel linkViewModel)
        {
            var link = Mapper.Map<LinkViewModel, Link>(linkViewModel);

            BeginTransaction();
            _linkService.Update(link);
            Commit();
        }

        public void Remove(LinkViewModel linkViewModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _linkService.Remove(id);
            Commit();
        }

        public IEnumerable<LinkViewModel> FindLinkViewModels(Expression<Func<LinkViewModel, bool>> predicate)
        {
            var mapperPredicate = Mapper.Map<Expression<Func<LinkViewModel, bool>>, Expression<Func<Link, bool>>>(predicate);
            
            return Mapper.Map<IEnumerable<Link>, IEnumerable<LinkViewModel>>(_linkService.Find(mapperPredicate));
        }

        public IEnumerable<LinkViewModel> PaginationFiltro(LinkViewModel linkViewModel, int linhasPorPagina, int pagina)
        {
            var link = Mapper.Map<LinkViewModel, Link>(linkViewModel);
            return Mapper.Map<IEnumerable<Link>, IEnumerable<LinkViewModel>>(_linkService.PaginationFiltro(link, linhasPorPagina, pagina));
        }

        public void Dispose()
        {
            _linkService.Dispose();
        }
    }
}