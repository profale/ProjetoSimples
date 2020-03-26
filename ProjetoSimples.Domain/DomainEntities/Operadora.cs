using System.Collections.Generic;

namespace ProjetoSimples.Domain.DomainEntities
{
    public class Operadora
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Categoria { get; set; }
        public virtual decimal Preco { get; set; }

        public virtual IList<Contato> Contatos { get; set; }

    }
}