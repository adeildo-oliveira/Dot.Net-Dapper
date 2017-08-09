using ProjetoArquivaLinks.Infra.CrossCutting.IoC;

namespace ProjetoArquivaLink.UI.MVC
{
    public class SimpleInjectorWeb
    {
        public static void Start()
        {
            SimpleInjectorModulo.LoadInjector();
        }
    }
}