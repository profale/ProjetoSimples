using ProjetoSimples.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoSimples.Domain.DomainEntities;
using ProjetoSimples.Infra.Context;

namespace ProjetoSimples.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class

    {
        private readonly DataContext context;

        public BaseRepository(DataContext context)
        {
            this.context = context;
        }

        public void Cadastrar(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Atualizar(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
        
        public void Excluir(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Obter(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IList<TEntity> ObterTodos()
        {
            return context.Set<TEntity>().ToList();
        }
    }
}
