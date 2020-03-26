using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoSimples.Domain.Contracts.DomainServices;
using ProjetoSimples.Domain.Contracts.Repositories;
using ProjetoSimples.Domain.DomainEntities;

namespace ProjetoSimples.Domain.DomainServices
{
    public class OperadoraDomainService : BaseDomainService<Operadora>, IOperadoraDomainService
    {
        private readonly IOperadoraRepository _operadoraRepository;

        public OperadoraDomainService(IOperadoraRepository operadoraRepository)
        : base(operadoraRepository)
        {
            _operadoraRepository = operadoraRepository;
        }
    }
}
