using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using GenericControllers.Extensions;
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
                .AddCors(co => co.AddDefaultPolicy(cpb => cpb.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .SetIsOriginAllowed(s => true)))
                .AddControllers()
                .AddGenericControllers(gco => gco
                    .AddController<GenericController<Company>>()
                    .AddController<GenericController<Employee>>());
            serviceCollection                    
                .AddSwaggerGen(sgo =>
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
        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                applicationBuilder
                    .UseDeveloperExceptionPage()
                    .UseSwagger()
                    .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GenericControllers v1"));
            }

            applicationBuilder
                // .UseHttpsRedirection()
                .UseCors()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
