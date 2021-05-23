using MicroMachines.EventBus.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;

namespace MicroMachines.EventBus.RabbitMQ
{
    public sealed class RabbitMQBus : IEventBus, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public RabbitMQBus(IOptions<RabbitMQSettings> settings, IServiceProvider provider, ILogger<RabbitMQBus> logger)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = settings.Value.HostName,
                    UserName = settings.Value.UserName,
                    Password = settings.Value.Password,
                    Port = int.Parse(settings.Value.Port)
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                logger.LogError("RabbitMQ client could not connect", ex.Message);
            }

            _serviceProvider = provider;
            _logger = logger;
        }

        public void Publish(IEvent @event)
        {
            using (var channel = _connection.CreateModel())
            {
                var eventName = @event.GetType().Name;
                var jsonEvent = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(jsonEvent);
                channel.BasicPublish(string.Empty, eventName, body: body);
            }         
        }

        public void Subsribe<T, TH>()
            where T : IEvent
            where TH : IEventHandler<T>
        {            
            using (var channel = _connection.CreateModel())
            {
                var eventName = typeof(T).Name;
                channel.QueueDeclare(eventName, durable: true, exclusive: false, autoDelete: false);

                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.Received += async (obj, args) =>
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var handler = scope.ServiceProvider.GetRequiredService<IEventHandler<T>>();
                        var jsonMessage = Encoding.UTF8.GetString(args.Body.ToArray());
                        var message = JsonConvert.DeserializeObject<T>(jsonMessage);

                        await handler.HandleAsync(message);
                        channel.BasicAck(args.DeliveryTag, false);
                    }
                };

                channel.BasicConsume(eventName, false, consumer);
            }
        }

        public void Dispose()
        {
            try
            {
                _connection.Dispose();
            }
            catch (IOException ex)
            {
                _logger.LogCritical(ex.ToString());
            }
        }
    }
}
