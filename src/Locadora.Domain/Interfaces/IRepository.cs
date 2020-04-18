using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity :  class
    {
        Task adicionarAsync(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task<TEntity> ObterPorId(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();

    }
}
