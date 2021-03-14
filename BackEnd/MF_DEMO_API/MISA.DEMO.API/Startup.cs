using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using MISA.DataLayer;
using MISA.Service.Services;
using MISA.Service;
using Newtonsoft.Json.Serialization;
using MISA.Service.Interfaces;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;
using MISA.DataLayer.Contexts;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MISA.DEMO.API
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
            //DbContext.connectionString = Configuration.GetConnectionString("LVHOANGConnection");
            //services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MISA.DEMO.API Service"
                    ,
                    Version = "v1"
                });
                c.CustomSchemaIds(type => type.ToString());
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

          
            services.AddScoped(typeof(IDbContext<>), typeof(DbContext<>));
          
            
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IWardRepository, WardRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
           
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IWardService, WardService>();
            services.AddScoped<IApplicationService, ApplicationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json"
                    , "MISA.DEMO.API Service V1");
                c.RoutePrefix = "swagger";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Xử lý ngoại lệ
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
                var _serviceResult = new ServiceResult
                {
                    Data = null,
                    Messenger = new List<string>() { Properties.Resources.Error_Exception },
                    MISACode = Common.Enum.MISAServiceCode.Exception
                };   

                var result = JsonConvert.SerializeObject(_serviceResult);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));
            
        }
    }
}
