using ExercicioPratico.Domain.DTOs;
using ExercicioPratico.Domain.Interfaces.Caching;
using ExercicioPratico.Domain.Models;
using ExercicioPratico.Infra.Caching.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Infra.Caching.Persistence
{
    public class CategoriaCaching: ICategoriaCaching
    {
        private readonly MongoDBContext mongoDBContext;

        public CategoriaCaching(MongoDBContext mongoDBContext)
        {
            this.mongoDBContext = mongoDBContext;
        }

        public void Add(CategoriaDTO obj)
        {
            mongoDBContext.Categorias.InsertOne(obj);
        }

        public void Update(CategoriaDTO obj)
        {
            var filter = Builders<CategoriaDTO>.Filter.Eq(c => c.Id, obj.Id);
            mongoDBContext.Categorias.ReplaceOne(filter,obj);
        }

        public void Remove(CategoriaDTO obj)
        {
            var filter = Builders<CategoriaDTO>.Filter.Eq(c => c.Id, obj.Id);
            mongoDBContext.Categorias.DeleteOne(filter);
        }

        public List<CategoriaDTO> FindAll()
        {
            var filter = Builders<CategoriaDTO>.Filter.Where(c=> true);
            return mongoDBContext.Categorias.Find(filter).ToList();
        }

        public CategoriaDTO FindyById(Guid id)
        {
            var filter = Builders<CategoriaDTO>.Filter.Eq(c => c.Id, id);
            return mongoDBContext.Categorias.Find(filter).FirstOrDefault();
        }
    }
}
