using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ProjetoArquivoLinks.Domain.Entities;
using ProjetoArquivoLinks.Infra.Data.EntityConfig;

namespace ProjetoArquivoLinks.Infra.Data.Context
{
    public class ProjetoArquivoLinksContext : BaseDbContext
    {
        public ProjetoArquivoLinksContext() : base("ArquivoLink")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        #region IDbSet Clase
        public IDbSet<Link> Link { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Quando houver ID no nome, configura como chave da tabela
            modelBuilder.Properties().Where(p => p.Name == "Id" + p.ReflectedType.Name).Configure(p => p.IsKey());

            //configura o campo como varchar no banco
            //modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //configura o tamanho do campo no banco de dados
            //modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(150));

            //Usar a configuração de campos da classe para configugar os campos do banco de dados
            modelBuilder.Configurations.Add(new LinkConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region SaveChanges
        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperties() != null))
            {
                var PropriedadeCadastro = item.Entity.GetType().GetProperties().Where(p => p.Name.ToUpper().Contains("DataCadastro".ToUpper())).Select(p => p.Name);

                foreach (var propriedade in PropriedadeCadastro)
                {
                    if (item.State == EntityState.Added || item.State == EntityState.Modified)
                    {
                        item.Property(propriedade.ToString()).CurrentValue = DateTime.Now;
                    }
                    else
                    {
                        item.Property(propriedade.ToString()).IsModified = false;
                    }
                }

                var PropriedadeStatus = item.Entity.GetType().GetProperties().Where(p => p.Name.ToUpper().Contains("Status".ToUpper())).Select(p => p.Name);
                foreach (var propriedade in PropriedadeStatus)
                {
                    if (item.State == EntityState.Added || item.State == EntityState.Modified)
                    {
                        item.Property(propriedade.ToString()).CurrentValue = true;
                    }
                }
            }

            return base.SaveChanges();
        }
        #endregion
    }
}