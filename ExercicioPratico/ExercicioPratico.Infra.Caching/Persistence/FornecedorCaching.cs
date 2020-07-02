using ExercicioPratico.Domain.DTOs;
using ExercicioPratico.Domain.Interfaces.Caching;
using ExercicioPratico.Infra.Caching.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Infra.Caching.Persistence
{
    public class FornecedorCaching: IFornecedorCaching
    {
        private readonly MongoDBContext mongoDBContext;

        public FornecedorCaching(MongoDBContext mongoDBContext)
        {
            this.mongoDBContext = mongoDBContext;
        }

        public void Add(FornecedorDTO obj)
        {
            mongoDBContext.Fornecedores.InsertOne(obj);
        }

        public void Update(FornecedorDTO obj)
        {
            var filter = Builders<FornecedorDTO>.Filter.Eq(c => c.Id, obj.Id);
            mongoDBContext.Fornecedores.ReplaceOne(filter, obj);
        }

        public void Remove(FornecedorDTO obj)
        {
            var filter = Builders<FornecedorDTO>.Filter.Eq(c => c.Id, obj.Id);
            mongoDBContext.Fornecedores.DeleteOne(filter);
        }

        public List<FornecedorDTO> FindAll()
        {
            var filter = Builders<FornecedorDTO>.Filter.Where(c => true);
            return mongoDBContext.Fornecedores.Find(filter).ToList();
        }

        public FornecedorDTO FindyById(Guid id)
        {
            var filter = Builders<FornecedorDTO>.Filter.Eq(c => c.Id, id);
            return mongoDBContext.Fornecedores.Find(filter).FirstOrDefault();
        }
    }
}
