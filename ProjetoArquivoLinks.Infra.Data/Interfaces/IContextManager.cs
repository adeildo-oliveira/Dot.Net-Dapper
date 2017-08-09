namespace ProjetoArquivoLinks.Infra.Data.Interfaces
{
    //IDbContex precisa ser inicializado atravês do new
    public interface IContextManager<TContext> where TContext : IDbContext, new()
    {
        IDbContext GetContext();
    }
}