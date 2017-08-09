using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ProjetoArquivoLinks.Infra.Data.Repositories.ADO
{
    public class BaseAdoRepository
    {
        public Database Connection => new DatabaseProviderFactory().Create("ArquivoLink");
    }
}