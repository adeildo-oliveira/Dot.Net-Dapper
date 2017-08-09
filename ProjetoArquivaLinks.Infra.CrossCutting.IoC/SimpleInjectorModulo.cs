using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using CommonServiceLocator.SimpleInjectorAdapter;
using Microsoft.Practices.ServiceLocation;
using ProjetoArquivoLinks.Aplication;
using ProjetoArquivoLinks.Aplication.Interfaces;
using ProjetoArquivoLinks.Domain.Interfaces.Repository;
using ProjetoArquivoLinks.Domain.Interfaces.Repository.Dapper;
using ProjetoArquivoLinks.Domain.Interfaces.Services;
using ProjetoArquivoLinks.Domain.Services;
using ProjetoArquivoLinks.Infra.Data.Context;
using ProjetoArquivoLinks.Infra.Data.Interfaces;
using ProjetoArquivoLinks.Infra.Data.Repositories;
using ProjetoArquivoLinks.Infra.Data.Repositories.ADO;
using ProjetoArquivoLinks.Infra.Data.Repositories.Dapper;
using ProjetoArquivoLinks.Infra.Data.UoW;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace ProjetoArquivaLinks.Infra.CrossCutting.IoC
{
    public class SimpleInjectorModulo
    {
        public static void LoadInjector()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            //Aplication
            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>), Lifestyle.Scoped);
            container.Register<ILinkAppService, LinksAppService>(Lifestyle.Scoped);

            //Domain
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Scoped);
            container.Register<ILinkService, LinkService>(Lifestyle.Scoped);
            container.Register<ILinkAdoRepository, LinkAdoRepository>(Lifestyle.Scoped);
            container.Register<ILinkDapperRepository, LinkDapperRepository>(Lifestyle.Scoped);

            //Infra Data
            //container.RegisterDecorator(typeof(IRepositoryBase<>), typeof(RepositoryBase<,>), Lifestyle.Singleton);
            container.RegisterDecorator(typeof(IRepositoryBase<>), 
                factoryContext => typeof(RepositoryBase<,>).MakeGenericType(typeof(RepositoryBase<,>).GetGenericArguments().First(), 
                factoryContext.ImplementationType), Lifestyle.Scoped, predicateContext => true);
            container.Register<ILinkRepository, LinkRepository>(Lifestyle.Scoped);

            container.Register(typeof(IContextManager<>), typeof(ContextManager<>), Lifestyle.Scoped);
            container.Register<IDbContext, ProjetoArquivoLinksContext>(Lifestyle.Scoped);
            container.Register(typeof(IUnitOfWork<>), typeof(UnitOfWork<>), Lifestyle.Scoped);

            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));

            container.Verify();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}