using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Locadora.Infra.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {

        protected readonly DataContext _dataContext;
        protected readonly DbSet<TEntity> _dbSet;



        //Injeção - Classe não instanciada,  porem  esse construtor requer  
        //argumentos em que  a classe que chama-la devera passar.
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<TEntity>();

            

        }

        public async Task adicionarAsync(TEntity entity)
        {
            _dbSet.Add(entity);

            
            await SaveChanges();
        }

        public async Task Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async  Task Remover(Guid id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(id));
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}
