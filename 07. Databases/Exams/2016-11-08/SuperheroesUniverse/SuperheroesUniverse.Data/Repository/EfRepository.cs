using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using SuperheroesUniverse.Data.Repository.Contracts;

namespace SuperheroesUniverse.Data.Repository
{
    public class EfRepository<T> : IEfRepository<T> where T : class
    {
        private readonly IDbSet<T> dbSet;
        private readonly DbContext context;

        public EfRepository(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException("Passed context is null!");
            this.dbSet = this.context.Set<T>();
        }

        public void Add(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public IEnumerable<T> GetAllFiltered(Expression<Func<T, bool>> filterExpression)
        {
            return this.dbSet.Where(filterExpression).ToList();
        }

        public T GetById(int id)
        {
            var entity = this.dbSet.Find(id);
            return entity;
        }

        public void Update(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
