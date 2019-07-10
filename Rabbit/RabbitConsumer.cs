using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace delegateTutorial
{
    public interface IRabbitConsumer
    {
        void SetChannel(string channel);
    }

    public class RabbitConsumer : IRabbitConsumer
    {
        private ConnectionFactory _factory;
        private IConnection _connect;
        private IModel _channel;
        private EventingBasicConsumer _consumer;

        public RabbitConsumer(IRabbitFactory factory)
        {
            _factory = factory.Create();
        }

        public void SetChannel(string channel)
        {
            _connect = _factory.CreateConnection();
            _channel = _connect.CreateModel();
            _consumer = new EventingBasicConsumer(_channel);

            _consumer.Received += (ch, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body);
                Console.WriteLine($"{channel} 收到消息：{message}");
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume(channel, false, _consumer);
        }
    }
}