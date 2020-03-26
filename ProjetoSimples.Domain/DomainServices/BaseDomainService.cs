using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoSimples.Domain.Contracts.DomainServices;
using ProjetoSimples.Domain.Contracts.Repositories;

namespace ProjetoSimples.Domain.DomainServices
{
    public class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
    where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseDomainService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Cadastrar(TEntity obj)
        {
            _repository.Cadastrar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _repository.Atualizar(obj);
        }

        public void Deletar(TEntity obj)
        {
            _repository.Excluir(obj);
        }

        public TEntity Obter(int id)
        {
           return _repository.Obter(id);
        }

        public IList<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }
    }
}
