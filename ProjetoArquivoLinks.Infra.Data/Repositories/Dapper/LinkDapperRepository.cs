using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ProjetoArquivoLinks.Domain.Entities;
using ProjetoArquivoLinks.Domain.Interfaces.Repository.Dapper;
using Dapper;

namespace ProjetoArquivoLinks.Infra.Data.Repositories.Dapper
{
    public class LinkDapperRepository : GetConnectionDapper, ILinkDapperRepository
    {
        public IEnumerable<Link> PaginationFiltro(Link linkEntity, int linhasPorPagina, int pagina)
        {
            using (var conn = Connection)
            {
                var sql = @"SELECT IdLink, Url, DescricaoLink, ComentarioLink, COUNT(IdLink) over() as TotalPage FROM Link 
                            WHERE StatusLink = 1 AND (Url like '%'+ @filtroLink +'%' OR DescricaoLink like '%'+ @filtroLink +'%')";
                var filtro = string.Empty;

                if (!string.IsNullOrEmpty(linkEntity.Url))
                    filtro = linkEntity.Url;

                if (!string.IsNullOrEmpty(linkEntity.DescricaoLink))
                    filtro = linkEntity.DescricaoLink;

                sql += string.Format(@" ORDER BY cast(Url as varchar(max)), cast(DescricaoLink as varchar(max)) OFFSET {1} * ({0} - 1) ROWS FETCH NEXT {1} ROWS ONLY"
                        , pagina, linhasPorPagina);

                conn.Open();
                return conn.Query<Link>(sql, new { filtroLink = filtro }).ToList();
            }
        }

        public void Remove(Guid id)
        {
            using (var conn = Connection)
            {
                const string sql = @"UPDATE Link SET StatusLink = 0 where IdLink = @idLink";
                conn.Open();
                conn.Execute(sql, new { idLink = id });
            }
        }
    }
}