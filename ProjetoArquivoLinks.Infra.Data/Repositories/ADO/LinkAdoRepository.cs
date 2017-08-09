using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Input;
using ProjetoArquivoLinks.Domain.Entities;
using ProjetoArquivoLinks.Domain.Interfaces.Repository;

namespace ProjetoArquivoLinks.Infra.Data.Repositories.ADO
{
    public class LinkAdoRepository : BaseAdoRepository, ILinkAdoRepository
    {
        public IEnumerable<Link> PaginationFiltro(Link linkEntity, int linhasPorPagina, int pagina)
        {
            var links = new List<Link>();
            
            using (var cmd = Connection.CreateConnection().CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT IdLink, Url, DescricaoLink, ComentarioLink, COUNT(IdLink) over() as PAGINAS FROM Link 
                            WHERE 1=1";

                if (!string.IsNullOrEmpty(linkEntity.Url))
                {
                    cmd.CommandText += " AND Url like '%?%'";
                    cmd.Parameters.Add(new SqlParameter("@url", linkEntity.Url));
                }

                if (!string.IsNullOrEmpty(linkEntity.DescricaoLink))
                {
                    cmd.CommandText += !string.IsNullOrEmpty(linkEntity.Url) ? " OR DescricaoLink like '%?%'" : " AND DescricaoLink like '%?%'";
                    cmd.Parameters.Add(new SqlParameter("@descricao", linkEntity.DescricaoLink));
                }
                cmd.CommandText += string.Format(@" AND (StatusLink = 1)
                    ORDER BY CONVERT(varchar, Url) OFFSET {1} * ({0} - 1) ROWS FETCH NEXT {1} ROWS ONLY", pagina, linhasPorPagina);
                

                using (IDataReader reader = Connection.ExecuteReader(CommandType.Text, cmd.CommandText))
                {
                    while (reader.Read())
                    {
                        var link = new Link();

                        link.IdLink = Guid.Parse(reader["IdLink"].ToString());
                        link.Url = reader["Url"].ToString();
                        link.DescricaoLink = reader["DescricaoLink"].ToString();
                        link.ComentarioLink = reader["ComentarioLink"].ToString();
                        link.TotalPage = (int)reader["PAGINAS"];

                        links.Add(link);
                    }
                }
            }

            return links;
        }
    }
}