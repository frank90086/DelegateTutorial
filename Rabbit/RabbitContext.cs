using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace delegateTutorial
{
    public interface IRabbitContext
    {
        void SetChannel(string channel);
        void AddQueue(string queueName);
        void RemoveQueue(string queueName);
        void SendAll(string msg);
        void SendDirection(string msg, string queueName);
        string QueueList { get; }
    }

    public class RabbitContext : IRabbitContext
    {
        private readonly ConnectionFactory _factory;
        private IConnection _connect;
        private IModel _channel;
        private List<string> _queueList = new List<string>();
        public string QueueList {
            get => String.Join(',', _queueList);
            private set { }
        }

        public RabbitContext(IRabbitFactory factory)
        {
            _factory = factory.Create();
        }

        public void SetChannel(string channel)
        {
            _connect = _factory.CreateConnection();
            _channel = _connect.CreateModel();
            AddQueue(channel);
        }

        public void AddQueue(string queueName)
        {
            _queueList.Add(queueName);
            _channel.QueueDeclare(queueName, false, false, false, null);
        }

        public void RemoveQueue(string queueName)
        {
            _queueList.Remove(queueName);
            _channel.QueueDelete(queueName);
        }

        public void SendAll(string msg)
        {
            foreach (var queueName in _queueList)
                SendDirection(msg, queueName);
        }

        public void SendDirection(string msg, string queueName)
        {
            var sendBytes = Encoding.UTF8.GetBytes(msg);
            _channel.BasicPublish("", queueName, null, sendBytes);
        }
    }
}