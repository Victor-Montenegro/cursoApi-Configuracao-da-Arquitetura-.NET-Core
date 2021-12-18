using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace curso.api
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
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSwaggerGen(x => 
            {
                //Realizando configuracao para realizar a inserção de autorizacao no swagger
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using Bearer security",
                    Name = "Authorization",
                    In = ParameterLocation.Header, // parametro que defini a entrada do token
                    Type = SecuritySchemeType.ApiKey, // o tipo de token
                    Scheme = "Bearer"
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                x.SwaggerDoc("v1", new OpenApiInfo { Title = "CursoAPI", Version = "v1" }); 
            
            });

            var secret = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtConfigurations:Secret").Value);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
            })
            .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;  
                    x.TokenValidationParameters = new TokenValidationParameters()  
                    {
                        ValidateIssuerSigningKey = true, 
                        IssuerSigningKey = new SymmetricSecurityKey(secret),  
                        ValidateIssuer = false, 
                        ValidateAudience = false
                    };
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api curso");
            //    c.RoutePrefix = string.Empty;
            //});
            app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "CursoAPI"); });
        }
    }
}
