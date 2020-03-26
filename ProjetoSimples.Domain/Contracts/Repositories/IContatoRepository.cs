using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoSimples.Domain.DomainEntities;

namespace ProjetoSimples.Domain.Contracts.Repositories
{
    public interface IContatoRepository : IBaseRepository<Contato>
    {
    }
}
