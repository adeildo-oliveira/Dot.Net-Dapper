using System;
using System.Collections.Generic;
using ProjetoArquivoLinks.Domain.Entities;
using ProjetoArquivoLinks.Domain.Interfaces.Repository;
using ProjetoArquivoLinks.Domain.Interfaces.Repository.Dapper;
using ProjetoArquivoLinks.Domain.Interfaces.Services;

namespace ProjetoArquivoLinks.Domain.Services
{
    public class LinkService : ServiceBase<Link>, ILinkService
    {
        private readonly ILinkRepository _linkRepository;
        private readonly ILinkAdoRepository _linkAdoRepository;
        private readonly ILinkDapperRepository _linkDapperRepository;

        public LinkService(ILinkRepository linkRepository, ILinkAdoRepository linkAdoRepository, ILinkDapperRepository linkDapperRepository) : base(linkRepository)
        {
            _linkRepository = linkRepository;
            _linkAdoRepository = linkAdoRepository;
            _linkDapperRepository = linkDapperRepository;
        }

        public IEnumerable<Link> PaginationFiltro(Link link, int linhasPorPagina, int pagina)
        {
            return _linkDapperRepository.PaginationFiltro(link, linhasPorPagina, pagina);
        }

        public void Remove(Guid id)
        {
            _linkDapperRepository.Remove(id);
        }
    }
}