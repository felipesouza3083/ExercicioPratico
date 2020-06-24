using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExercicioPratico.CrossCutting.IoC;
using ExercicioPratico.Services.API.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExercicioPratico.Services.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            SwaggerSetup.AddSwaggerSetup(services);

            EntityFrameworkSetup.AddEntityFrameworkSetup(services, Configuration);

            JwtBearerSetup.AddJwtBearerSetup(services, Configuration);

            DependencyInjection.Register(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            JwtBearerSetup.UseJwtBearerSetup(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SwaggerSetup.UseSwaggerSetup(app);
        }
    }
}
