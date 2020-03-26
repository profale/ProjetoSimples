using ProjetoSimples.Domain.DomainEntities;
using ProjetoSimples.Infra.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSimples.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        : base("ProjetoSimples")
        {
            Database.SetInitializer<DataContext>(null);
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
            modelBuilder.HasDefaultSchema("dbo");

            //Entidade
            modelBuilder.Entity<Contato>().ToTable("PS_CONTATO");
            modelBuilder.Entity<Operadora>().ToTable("PS_OPERADORA");

            //Mapeamento
            modelBuilder.Configurations.Add(new ContatoMap());
            modelBuilder.Configurations.Add(new OperadoraMap());
        }

        //DBSET
        public DbSet<Contato> Contato {get; set;}
        public DbSet<Operadora> Operadora { get; set; }
    }
}
