using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Consumer.Helper
{
    public class RabbitMQHelper : IRabbitMQHelper
    {
        public ConnectionFactory GetConnectionFactory()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost", //dockerbackoffice
                //UserName = "guest",
                //Password = "guest",
            };

            return connectionFactory;
        }

        public IConnection CreateConnection(ConnectionFactory connectionFactory)
        {
            return connectionFactory.CreateConnection();
        }

        public QueueDeclareOk CreateQueue(string queueName, IModel channel)
        {
            QueueDeclareOk queue;

            queue = channel.QueueDeclare(queueName, false, false, false, null);

            return queue;
        }

        public EventingBasicConsumer CreateConsumer(IModel channel)
        {
            EventingBasicConsumer consumer;

            consumer = new EventingBasicConsumer(channel);

            return consumer;
        }

        public void WriteMessageOnQueue(string message, string queueName, IModel channel)
        {
            channel.BasicPublish(exchange: string.Empty, routingKey: queueName, basicProperties: null, body: Encoding.UTF8.GetBytes(message));
        }

        public void ReceiveMessageFromQueue(string queueName, EventingBasicConsumer eventing, IModel channel)
        {
            channel.BasicConsume(queue: queueName, autoAck: true, consumer: eventing);
        }

        private uint RetrieveMessageCount(string queueName, IModel channel) //change public if use
        {
            uint count = channel.MessageCount(queueName);

            return count;
        }
    }
}