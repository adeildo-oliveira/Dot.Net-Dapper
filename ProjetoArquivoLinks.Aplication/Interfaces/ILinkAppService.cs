using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ProjetoArquivoLinks.Aplication.ViewModels;

namespace ProjetoArquivoLinks.Aplication.Interfaces
{
    public interface ILinkAppService : IDisposable
    {
        void Add(LinkViewModel linkViewModel);
        LinkViewModel GetById(Guid id);
        IEnumerable<LinkViewModel> GetAll();
        void Update(LinkViewModel linkViewModel);
        void Remove(LinkViewModel linkViewModel);
        void Remove(Guid id);
        IEnumerable<LinkViewModel> FindLinkViewModels(Expression<Func<LinkViewModel, bool>> predicate);
        IEnumerable<LinkViewModel> PaginationFiltro(LinkViewModel linkViewModel, int linhasPorPagina, int pagina);
    }
}