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
    public class OperadoraRepository : BaseRepository<Operadora>, IOperadoraRepository
    {
        private readonly DataContext _context;

        public OperadoraRepository(DataContext context)
        :base(context)
        {
            _context = context;
        }
    }
}
