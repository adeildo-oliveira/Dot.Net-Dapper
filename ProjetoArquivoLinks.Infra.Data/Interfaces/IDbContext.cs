using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ProjetoArquivoLinks.Infra.Data.Interfaces
{
    public interface IDbContext
    {
        //Abstraindo os métodos do dbcontext do entity framework para utilizar injeção de dependência
        IDbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
        void Dispose();
    }
}