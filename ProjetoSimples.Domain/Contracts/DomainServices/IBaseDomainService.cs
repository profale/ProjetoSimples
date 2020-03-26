using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSimples.Domain.Contracts.DomainServices
{
    public interface IBaseDomainService<TEntity>
        where TEntity: class
    {
        void Cadastrar(TEntity obj);
        void Atualizar(TEntity obj);
        void Deletar(TEntity obj);
        TEntity Obter(int id);
        IList<TEntity> ObterTodos();
    }
}
