using System;
using System.Collections.Generic;
using ProjetoArquivoLinks.Domain.Entities;

namespace ProjetoArquivoLinks.Domain.Interfaces.Services
{
    public interface ILinkService : IServiceBase<Link>
    {
        IEnumerable<Link> PaginationFiltro(Link link, int linhasPorPagina, int pagina);
        void Remove(Guid id);
    }
}