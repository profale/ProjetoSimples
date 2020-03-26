using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoSimples.Domain.Contracts.Repositories;
using ProjetoSimples.Domain.DomainEntities;
using ProjetoSimples.Infra.Context;

namespace ProjetoSimples.Infra.Repositories
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        private readonly DataContext context;

        public ContatoRepository(DataContext context)
            :base(context)
        {
            this.context = context;
        }
    }
}
