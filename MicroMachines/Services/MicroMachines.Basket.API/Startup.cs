using MicroMachines.Basket.API.Clients;
using MicroMachines.Basket.API.Repositories;
using MicroMachines.EventBus.Interfaces;
using MicroMachines.EventBus.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace MicroMachines.Basket.API
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
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetValue<string>("CacheSettings:ConnectionString");
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroMachines.MicroMachines.Basket.API", Version = "v1" });
            });

            services.Configure<RabbitMQSettings>(option =>
            {
                Configuration.GetSection("EventBus").Bind(option);
            });

            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton<IEventBus, RabbitMQBus>();

            services.AddHttpClient<CatalogClient>(client =>
            {
                client.BaseAddress = Configuration.GetValue<Uri>("CatalogApiClient");
            });

            services.AddHttpClient<ITransferClient, TransferClient>(client =>
            {
                client.BaseAddress = Configuration.GetValue<Uri>("TransferApiClient");
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MicroMachines.MicroMachines.Basket.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
