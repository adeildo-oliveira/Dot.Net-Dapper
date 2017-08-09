using CommonServiceLocator.SimpleInjectorAdapter;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;

namespace ProjetoArquivaLinks.Infra.CrossCutting.IoC
{
    public class ContainerInjector
    {
        public ContainerInjector()
        {
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(new Container()));
        }
        
    }
}