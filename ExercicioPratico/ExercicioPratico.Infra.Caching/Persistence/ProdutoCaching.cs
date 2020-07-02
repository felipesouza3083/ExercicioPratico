using ExercicioPratico.Domain.DTOs;
using ExercicioPratico.Domain.Interfaces.Caching;
using ExercicioPratico.Infra.Caching.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Infra.Caching.Persistence
{
    public class ProdutoCaching: IProdutoCaching
    {
        private readonly MongoDBContext mongoDBContext;

        public ProdutoCaching(MongoDBContext mongoDBContext)
        {
            this.mongoDBContext = mongoDBContext;
        }

        public void Add(ProdutoDTO obj)
        {
            mongoDBContext.Produtos.InsertOne(obj);
        }

        public void Update(ProdutoDTO obj)
        {
            var filter = Builders<ProdutoDTO>.Filter.Eq(c => c.Id, obj.Id);
            mongoDBContext.Produtos.ReplaceOne(filter, obj);
        }

        public void Remove(ProdutoDTO obj)
        {
            var filter = Builders<ProdutoDTO>.Filter.Eq(c => c.Id, obj.Id);
            mongoDBContext.Produtos.DeleteOne(filter);
        }

        public List<ProdutoDTO> FindAll()
        {
            var filter = Builders<ProdutoDTO>.Filter.Where(c => true);
            return mongoDBContext.Produtos.Find(filter).ToList();
        }

        public ProdutoDTO FindyById(Guid id)
        {
            var filter = Builders<ProdutoDTO>.Filter.Eq(c => c.Id, id);
            return mongoDBContext.Produtos.Find(filter).FirstOrDefault();
        }
    }
}
