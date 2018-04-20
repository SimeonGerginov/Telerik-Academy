using System;
using System.Data.Entity;

using SuperheroesUniverse.Data.Repository.Contracts;

namespace SuperheroesUniverse.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context ?? throw new ArgumentNullException("Passed context is null!");
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
