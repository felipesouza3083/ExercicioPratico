using ExercicioPratico.Domain.Interfaces.Repositories;
using ExercicioPratico.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercicioPratico.Domain.Services
{
    public abstract class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity> repository;

        protected BaseDomainService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual void Add(TEntity obj)
        {
            repository.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            repository.Update(obj);
        }

        public virtual void Remove(TEntity obj)
        {
            repository.Remove(obj);
        }

        public virtual List<TEntity> GetAll()
        {
            return repository.FindAll().ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return repository.FindyById(id);
        }

        public virtual void Dispose()
        {
            repository.Dispose();
        }
    }
}
