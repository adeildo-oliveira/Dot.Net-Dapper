using System.Collections.Generic;

namespace ProjetoArquivoLinks.Domain.Interfaces.Repository
{
    public interface IBaseAdoRepository<TEntity>
    {
        IEnumerable<TEntity> PaginationFiltro(TEntity linkEntity, int linhasPorPagina, int pagina);
    }
}