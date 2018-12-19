using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APISmartCity.Controllers;
using APISmartCity.ExceptionPackage;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace APISmartCity
{
    public class Startup
    {
        //TODO : Créer des constantes pour le serveur par exemple
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SCNConnectDBContext>((options) =>
            {
                string connectionString = new ConfigurationHelper("Connection").GetConnectionString();
                options.UseSqlServer(connectionString);
            });

            string SecretKey = Constantes.CLE_SECRETE_JETON;
            SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = Constantes.NOM_SERVEUR_JETON;
                options.Audience = Constantes.URL_SERVEUR_JETON;
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = Constantes.NOM_SERVEUR_JETON,

                ValidateAudience = true,
                ValidAudience = Constantes.URL_SERVEUR_JETON,

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
                        options.Audience = Constantes.URL_SERVEUR_JETON;
                        options.ClaimsIssuer = Constantes.NOM_SERVEUR_JETON;
                        options.TokenValidationParameters = tokenValidationParameters;
                        options.SaveToken = true;
                    });
            //pour ajouter CORS services (authoriser les requetes cross origin)
            //services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader();
                });
            });
            services.AddMvc((options) =>
            {
                options.Filters.Add(typeof(PersonnalExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //automapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Model.LoginModel, DTO.LoginModelDTO>();
                cfg.CreateMap<DTO.LoginModelDTO, Model.LoginModel>();
                cfg.CreateMap<DTO.OpeningPeriodDTO, Model.OpeningPeriod>();
                cfg.CreateMap<Model.OpeningPeriod, DTO.OpeningPeriodDTO>();
                cfg.CreateMap<Model.Commerce, DTO.CommerceDTO>();
                cfg.CreateMap<DTO.CommerceDTO, Model.Commerce>();
                cfg.CreateMap<DTO.UserDTO, Model.User>();
                cfg.CreateMap<Model.User, DTO.UserDTO>();
            });
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            //Swagger
            //app.useSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
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
