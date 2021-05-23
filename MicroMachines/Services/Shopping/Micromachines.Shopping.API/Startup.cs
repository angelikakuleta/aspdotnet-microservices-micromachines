using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MicroMachines.Shopping.Infrastructure.Data;
using MicroMachines.Shopping.Infrastructure.Repositories;
using MicroMachines.MicroMachines.Shopping.Domain.Interfaces;
using System.Reflection;
using FluentValidation.AspNetCore;
using MicroMachines.EventBus.RabbitMQ;
using MicroMachines.EventBus.Interfaces;
using MicroMachines.Shopping.Domain.Events;
using MicroMachines.Shopping.API.EventHandlers;

namespace MicroMachines.Shopping.API
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
            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("OrderConnectionString")));

            services.AddControllers()
                .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroMachines.Shopping.API", Version = "v1" });
            });

            services.Configure<RabbitMQSettings>(option =>
            {
                Configuration.GetSection("EventBus").Bind(option);
            });

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton<IEventBus, RabbitMQBus>();
            services.AddTransient<IEventHandler<BasketCheckoutAcceptedEvent>, BasketCheckoutAcceptedEventHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MicroMachines.Shopping.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureEventBus(app, env);           
        }

        private void ConfigureEventBus(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subsribe<BasketCheckoutAcceptedEvent, BasketCheckoutAcceptedEventHandler>();
        }
    }
}
