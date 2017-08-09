using System.Web;
using ProjetoArquivoLinks.Infra.Data.Interfaces;

namespace ProjetoArquivoLinks.Infra.Data.Context
{
    public class ContextManager<TContext> : IContextManager<TContext> where TContext : IDbContext, new()
    {
        //OneContextPerRequest
        private const string Contextkey = "ContextManager.Context";
        public IDbContext GetContext()
        {
            if (HttpContext.Current.Items[Contextkey] == null)
            {
                HttpContext.Current.Items[Contextkey] = new TContext();
            }

            return (IDbContext)HttpContext.Current.Items[Contextkey];
        }
    }
}