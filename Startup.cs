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
using GenericControllers.Controllers;
using GenericControllers.Extensions;
using GenericControllers.Features;
using GenericControllers.Models;

namespace GenericControllers
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddControllers(moa =>
                {
                    moa.AddGenericControllerNameConvention();
                })
                .AddGenericControllers(new GenericControllersOptions()
                    .AddGenericController(typeof(GenericController<>), new List<Type> { typeof(Company) })
                    .AddGenericController(typeof(GenericController<>), new List<Type> { typeof(Employee) })
                );
            serviceCollection.AddSwaggerGen(sgo =>
            {
                sgo.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "GenericControllers",
                        Version = "v1"
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GenericControllers v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
