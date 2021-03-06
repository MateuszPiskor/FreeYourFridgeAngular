using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using AutoMapper;
using FreeYourFridge.API.Data;
using FreeYourFridge.API.Data.Interfaces;
using FreeYourFridge.API.Helpers;
using FreeYourFridge.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using RestSharp;

namespace FreeYourFridge.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new ApiKeyReader());
            services.AddScoped<RestClient>();
            services.AddScoped<IMakePartialUrl, UrlMaker>();
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc(setupAction => { setupAction.ReturnHttpNotAcceptable = true; }).AddXmlDataContractSerializerFormatters().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc(option => option.EnableEndpointRouting = false);
            
            services.AddCors();
            services.AddAutoMapper(typeof(UserRepository).Assembly);
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IFridgeRepository, FridgeRepository>();
            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<IFavouredRepository, FavouredRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IShoppingListRepository, ShoppingListRepository>();
            services.AddScoped<IDailyMealRepository, DailyMealRepository>();
            services.AddScoped<DCICalculator>();
            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("FreeFridgeSpec", new OpenApiInfo()
                {
                    Title = "FreeYourFridgeAPI",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                    Name = "Authorization"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "Bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/FreeFridgeSpec/swagger.json", "FreeYourFridgeAPI");
                c.RoutePrefix = "";
            });
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc();


        }
    }
}
