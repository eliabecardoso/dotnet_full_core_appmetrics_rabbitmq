using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer.Helper
{
    public interface IRabbitMQHelper
    {
        ConnectionFactory GetConnectionFactory();
        IConnection CreateConnection(ConnectionFactory connectionFactory);
        EventingBasicConsumer CreateConsumer(IModel connection);
        QueueDeclareOk CreateQueue(string queueName, IModel channel);
        void WriteMessageOnQueue(string message, string queueName, IModel channel);
        void ReceiveMessageFromQueue(string queueName, EventingBasicConsumer eventing, IModel channel);
    }
}