
using ExercicioPratico.Infra.Caching.Contexts;
using ExercicioPratico.Infra.Caching.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioPratico.Services.API.Configurations
{
    public static class MongoDBSetup
    {
        public static void AddMongoDBSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var dbSettings = new MongoDBSettings();
            new ConfigureFromConfigurationOptions<MongoDBSettings>
                (configuration.GetSection("MongoDBSettings"))
                .Configure(dbSettings);

            services.AddSingleton(dbSettings);

            services.AddSingleton<MongoDBContext>();
        }
    }
}
