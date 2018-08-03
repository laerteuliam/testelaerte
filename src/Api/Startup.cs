using System.Reflection;
using Api.Filters;
using Application.Services;
using Domain.Contracts;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag.AspNetCore;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigCors(services);
            ConfigFilters(services);
            ConfigDbContext(services);
            ConfigDependencies(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        private static void ConfigDependencies(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Cliente>), typeof(ClienteRepository));
            services.AddScoped(typeof(IRepository<Pedido>), typeof(PedidoRepository));
            services.AddScoped(typeof(IService<Pedido>), typeof(PedidoService));
        }

        private void ConfigDbContext(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("TesteLaerteDb");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        }

        private static void ConfigFilters(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(DomainExceptionFilter));
                options.Filters.Add(typeof(NullReferenceExceptionFilter));
                options.Filters.Add(typeof(InvalidOperationExceptionFilter));
            });
        }

        private static void ConfigCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;
            });
        
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
