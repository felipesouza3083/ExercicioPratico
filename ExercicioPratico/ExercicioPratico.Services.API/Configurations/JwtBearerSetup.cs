using ExercicioPratico.CrossCutting.Security.Services;
using ExercicioPratico.CrossCutting.Security.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioPratico.Services.API.Configurations
{
    public static class JwtBearerSetup
    {
        public static void AddJwtBearerSetup(IServiceCollection services, IConfiguration configuration)
        {
            //lendo o código de segurança (Secret) contido no appsettings.json
            var settingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(settingsSection);

            var appSettings = settingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(
                      bearer =>
                      {
                          bearer.RequireHttpsMetadata = false;
                          bearer.SaveToken = true;
                          bearer.TokenValidationParameters
                              = new TokenValidationParameters
                              {
                                  ValidateIssuerSigningKey = true,
                                  IssuerSigningKey = new SymmetricSecurityKey(key),
                                  ValidateIssuer = false,
                                  ValidateAudience = false
                              };
                      }
                   );

            services.AddTransient(map => new TokenService(appSettings));
        }

        public static void UseJwtBearerSetup(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
