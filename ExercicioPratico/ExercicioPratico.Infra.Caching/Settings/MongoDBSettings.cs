using System;
using System.Collections.Generic;
using System.Text;

namespace ExercicioPratico.Infra.Caching.Settings
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public bool IsSSL { get; set; }
    }
}
