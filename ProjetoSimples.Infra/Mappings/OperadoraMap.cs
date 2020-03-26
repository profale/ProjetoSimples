using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoSimples.Domain.DomainEntities;

namespace ProjetoSimples.Infra.Mappings
{
    public class OperadoraMap : EntityTypeConfiguration<Operadora>
    {
        public OperadoraMap()
        {
            ToTable("PS_OPERADORA");
            HasKey(o => o.Id);
            Property(c => c.Id)
                .HasColumnName("PS_SEQ_OPERADORA");

            Property(c => c.Nome)
                .HasColumnName("PS_NOM_OPERADORA")
                .HasMaxLength(100);

            Property(o => o.Categoria)
                .HasColumnName("PS_NOM_CATEGORIA")
                .HasMaxLength(100);

            Property(o => o.Preco)
                .HasColumnName("PS_VLR_PRECO");

        }
    }
}
