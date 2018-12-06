using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APISmartCity.Controllers;
using APISmartCity.ExceptionPackage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace APISmartCity
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
            string SecretKey = "MaSuperCleSecreteAPasPublier";
            SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
            services.Configure<JwtIssuerOptions>(options => {
                options.Issuer = "MonSuperServeurDeJetons";
                options.Audience = "http://localhost:5000";
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters{
                ValidateIssuer = true,
                ValidIssuer = "MonSuperServeurDeJetons",

                ValidateAudience = true,
                ValidAudience = "http://localhost:5000",

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services
                .AddAuthentication(
                    options => 
                    {
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => 
                    {
                        options.Audience = "http://localhost:5000";
                        options.ClaimsIssuer = "MonSuperServeurDeJetons";
                        options.TokenValidationParameters = tokenValidationParameters;
                        options.SaveToken = true;
                    });
//pour ajouter CORS services (authoriser les requetes cross origin)
            //services.AddCors();
            services.AddCors(options =>{
                options.AddPolicy("AllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader();
                });
            }
        );
            services.AddMvc((options)=>
            {
               options.Filters.Add(typeof(PersonnalExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //Enable CORS with CORS Middleware
            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
                //builder.WithOrigins("http://localhost:4200")
                builder.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            //app.UseHttpsRedirection();
            app.UseMvc();

            
        }
    }
}
