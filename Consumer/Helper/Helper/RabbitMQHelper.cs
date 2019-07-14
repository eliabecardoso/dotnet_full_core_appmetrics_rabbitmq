using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AppOwinAppMetrics.Middlewares.Metrics.Helper
{
    public class RabbitMQHelper : IRabbitMQHelper
    {
        public ConnectionFactory GetConnectionFactory()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost", //dockerbackoffice
                UserName = "guest",
                Password = "guest",
            };

            return connectionFactory;
        }

        public IConnection CreateConnection(ConnectionFactory connectionFactory)
        {
            return connectionFactory.CreateConnection();
        }

        public QueueDeclareOk CreateQueue(string queueName, IConnection connection)
        {
            QueueDeclareOk queue;

            using (var channel = connection.CreateModel())
            {
                queue = channel.QueueDeclare(queueName, false, false, false, null);
            }

            return queue;
        }

        public EventingBasicConsumer CreateConsumer(IConnection connection)
        {
            EventingBasicConsumer consumer;

            using (var channel = connection.CreateModel())
            {
                consumer = new EventingBasicConsumer(channel);
            }

            return consumer;
        }

        public void WriteMessageOnQueue(string message, string queueName, IConnection connection)
        {
            using (var channel = connection.CreateModel())
            {
                channel.BasicPublish(exchange: string.Empty, routingKey: queueName, basicProperties: null, body: Encoding.UTF8.GetBytes(message));
            }
        }

        public void ReceiveMessageFromQueue(string queueName, EventingBasicConsumer eventing, IConnection connection)
        {
            using (var channel = connection.CreateModel())
            {
                channel.BasicConsume(queue: queueName, autoAck: true, consumer: eventing);
            }
        }

        private uint RetrieveMessageCount(string queueName, IConnection connection) //change public if use
        {
            uint count;
            using (var channel = connection.CreateModel())
            {
                count = channel.MessageCount(queueName);
            }

            return count;
        }
    }
}