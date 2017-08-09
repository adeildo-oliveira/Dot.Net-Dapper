using System.Data.Entity.ModelConfiguration;
using ProjetoArquivoLinks.Domain.Entities;

namespace ProjetoArquivoLinks.Infra.Data.EntityConfig
{
    public class LinkConfiguration : EntityTypeConfiguration<Link>
    {
        public LinkConfiguration()
        {
            HasKey(c => c.IdLink);

            Property(c => c.Url).IsRequired().HasColumnType("text");
            Property(c => c.DescricaoLink).IsRequired().HasColumnType("text");
            Property(c => c.ComentarioLink).HasColumnType("text");
            Property(c => c.StatusLink).IsRequired();

            //Ignore(c => c.ResultadoValidacao);
            Ignore(c => c.TotalPage);
        }
    }
}