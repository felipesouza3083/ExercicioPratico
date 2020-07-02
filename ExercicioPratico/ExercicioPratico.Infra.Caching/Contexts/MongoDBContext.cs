using ExercicioPratico.Domain.DTOs;
using ExercicioPratico.Infra.Caching.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Infra.Caching.Contexts
{
    public class MongoDBContext
    {
        private readonly MongoDBSettings mongoDBSettings;
        private IMongoDatabase mongoDatabase;

        public MongoDBContext(MongoDBSettings mongoDBSettings)
        {
            this.mongoDBSettings = mongoDBSettings;
            Initialize();
        }

        private void Initialize()
        {
            var settings = MongoClientSettings.FromUrl
                (new MongoUrl(mongoDBSettings.ConnectionString));

            if (mongoDBSettings.IsSSL)
            {
                settings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };
            }

            var client = new MongoClient(settings);
            mongoDatabase = client.GetDatabase(mongoDBSettings.DatabaseName);
        }

        public IMongoCollection<CategoriaDTO> Categorias { get { return mongoDatabase.GetCollection<CategoriaDTO>("Categorias"); } }
        public IMongoCollection<FornecedorDTO> Fornecedores { get { return mongoDatabase.GetCollection<FornecedorDTO>("Fornecedores"); } }
        public IMongoCollection<ProdutoDTO> Produtos { get { return mongoDatabase.GetCollection<ProdutoDTO>("Produtos"); } }
    }
}
