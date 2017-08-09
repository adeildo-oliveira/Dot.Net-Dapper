using ProjetoArquivoLinks.Domain.Entities;
using ProjetoArquivoLinks.Domain.Interfaces.Repository;
using ProjetoArquivoLinks.Infra.Data.Context;

namespace ProjetoArquivoLinks.Infra.Data.Repositories
{
    public class LinkRepository : RepositoryBase<Link, ProjetoArquivoLinksContext>, ILinkRepository
    {
        
    }
}