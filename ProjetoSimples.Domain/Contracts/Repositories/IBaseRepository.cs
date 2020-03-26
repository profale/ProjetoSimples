using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSimples.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity: class
    {
        void Cadastrar(TEntity obj);
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        TEntity Obter(int id);
        IList<TEntity> ObterTodos();
    }
}
