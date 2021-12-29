using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartSchool.WebAPI.Data;

namespace SmartSchool
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
            services.AddDbContext<SmartContext>(
                context => context.UseMySql(Configuration.GetConnectionString("MySqlConnection"),
                mySqlOptionsAction: Options => {
                    Options.EnableRetryOnFailure();
                })
            );

            services.AddControllers()
                    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = 
                                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());                                
            services.AddScoped<IRepository, Repository>();
            services.AddVersionedApiExplorer(options => {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            })
            .AddApiVersioning(options => {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1,0);
                options.ReportApiVersions = true;
            });

            var apiProviverDescription = services.BuildServiceProvider()
                                                 .GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(
                options => {
                    foreach (var description in apiProviverDescription.ApiVersionDescriptions)
                    {   
                        options.SwaggerDoc(
                        
                            description.GroupName, 
                            new Microsoft.OpenApi.Models.OpenApiInfo(){
                                Title = "Smart School API",
                                Version =  description.ApiVersion.ToString(),
                                TermsOfService = new Uri("https://seustermos.com"),
                        });
                     }
                }
            );  


        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiProviverDescription)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger()
                .UseSwaggerUI(
                    options => {
                        foreach (var description in apiProviverDescription.ApiVersionDescriptions)
                        {
                            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                            
                        }
                        options.RoutePrefix = "";
                    }
                );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
