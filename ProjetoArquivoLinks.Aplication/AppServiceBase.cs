using System;
using Microsoft.Practices.ServiceLocation;
using ProjetoArquivoLinks.Aplication.Interfaces;
using ProjetoArquivoLinks.Infra.Data.Interfaces;

namespace ProjetoArquivoLinks.Aplication
{
    public class AppServiceBase<TContext> : IAppServiceBase<TContext> where TContext : IDbContext, new()
    {
        private IUnitOfWork<TContext> _uow;
        public void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.SaveChanges();
        }
    }
}