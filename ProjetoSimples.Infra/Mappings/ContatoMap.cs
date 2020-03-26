using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoSimples.Domain.DomainEntities;

namespace ProjetoSimples.Infra.Mappings
{
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public ContatoMap()
        {
            ToTable("PS_CONTATO");
            HasKey(c => c.Id);
            Property(c => c.Id)
                .HasColumnName("PS_SEQ_CONTATO")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Nome)
                .HasColumnName("PS_NOM_CONTATO")
                .HasMaxLength(100);

            Property(c => c.Cor)
                .HasColumnName("PS_NOM_COR");

            Property(c => c.Data)
                .HasColumnName("PS_DTA_REGISTRO");

            Property(c => c.Telefone)
                .HasColumnName("PS_NOM_TELEFONE");

            Property(c => c.IdOperadora)
                .HasColumnName("PS_SEQ_OPERADORA");

            Property(c => c.Serial)
                .HasColumnName("PS_NOM_SERIAL");

            HasRequired(c => c.Operadora)
            .WithMany(o => o.Contatos)
            .HasForeignKey(c => c.IdOperadora);

        }
    }
}
