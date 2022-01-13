using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Api.Auth.Services;
using Api.Auth.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Api.Auth
{
    public static class AuthStartupExtensions
    {
        public static void ConfigureAuthServices(this IServiceCollection services, IConfiguration configuration)
        {          
            services.AddSingleton<ITokenService, TokenService>(s => new TokenService(configuration));

            services
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.IncludeErrorDetails = true;
                x.TokenValidationParameters = TokenService.GetTokenValidationParameters(configuration);
                x.Events = new JwtBearerEvents  
                {  
                  OnAuthenticationFailed = context =>  
                  {  
                      // debug "invalid token" scenarios here
                      var exType = context.Exception.GetType();
                      return Task.CompletedTask;  
                  },
                  OnTokenValidated = context =>
                  {
                      var xxx = context;
                      return Task.CompletedTask;
                  },
                  OnForbidden = context =>
                  {
                      var xxx = context;
                      return Task.CompletedTask;
                  }
              };  
            });

            services.AddDbContext<AuthContext>(options => options.UseMySQL(configuration["ConnectionStrings:DefaultConnection"]));
        }
    }   
}