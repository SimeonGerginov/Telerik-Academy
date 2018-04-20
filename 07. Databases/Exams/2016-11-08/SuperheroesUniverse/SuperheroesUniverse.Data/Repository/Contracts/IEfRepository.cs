using System.Collections.Generic;

namespace SuperheroesUniverse.Data.Repository.Contracts
{
    public interface IEfRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        T GetById(int id);
    }
}
