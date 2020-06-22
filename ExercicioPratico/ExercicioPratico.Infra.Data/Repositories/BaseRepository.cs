using ExercicioPratico.Domain.Interfaces.Repositories;
using ExercicioPratico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercicioPratico.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        protected readonly SqlContext context;
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(SqlContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            context.Add(obj);
            context.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            context.Update(obj);
            context.SaveChanges();
        }

        public virtual void Remove(TEntity obj)
        {
            context.Remove(obj);
            context.SaveChanges();
        }

        public virtual IQueryable<TEntity> FindAll()
        {
            return dbSet;
        }

        public virtual TEntity FindyById(Guid id)
        {
            return dbSet.Find(id);
        }

        public virtual void Dispose()
        {
            context.Dispose();
        }
    }
}
