using ProjetoArquivoLinks.Infra.Data.Interfaces;

namespace ProjetoArquivoLinks.Aplication.Interfaces
{
    public interface IAppServiceBase<TContext> where TContext : IDbContext
    {
        void BeginTransaction();
        void Commit();
    }
}