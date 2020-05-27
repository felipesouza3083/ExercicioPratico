using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercicioPratico.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        IQueryable<TEntity> FindAll();
        TEntity FindyById(int id);
    }
}
