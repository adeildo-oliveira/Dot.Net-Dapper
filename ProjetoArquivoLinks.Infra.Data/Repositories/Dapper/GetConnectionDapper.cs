using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoArquivoLinks.Infra.Data.Repositories.Dapper
{
    public class GetConnectionDapper
    {
        public IDbConnection Connection => new SqlConnection(ConfigurationManager.ConnectionStrings["ArquivoLink"].ConnectionString);
    }
}