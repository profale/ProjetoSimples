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
    public class ContatoDomainService : BaseDomainService<Contato>, IContatoDomainService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoDomainService(IContatoRepository contatoRepository)
            :base(contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }


    }
}
