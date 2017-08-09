using System.Data.Entity;
using ProjetoArquivoLinks.Infra.Data.Interfaces;

namespace ProjetoArquivoLinks.Infra.Data.Context
{
    public class BaseDbContext : DbContext, IDbContext
    {
        //herda o método para obter a connection através de injenção de dependência
        public BaseDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}