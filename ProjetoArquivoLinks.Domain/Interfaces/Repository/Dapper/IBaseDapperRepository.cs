using System;
using System.Collections.Generic;

namespace ProjetoArquivoLinks.Domain.Interfaces.Repository.Dapper
{
    public interface IBaseDapperRepository<TEntity>
    {
        IEnumerable<TEntity> PaginationFiltro(TEntity linkEntity, int linhasPorPagina, int pagina);
        void Remove(Guid id);
    }
}