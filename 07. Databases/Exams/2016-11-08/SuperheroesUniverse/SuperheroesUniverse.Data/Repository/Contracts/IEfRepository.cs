using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SuperheroesUniverse.Data.Repository.Contracts
{
    public interface IEfRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllFiltered(Expression<Func<T, bool>> filterExpression);

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        T GetById(int id);
    }
}
