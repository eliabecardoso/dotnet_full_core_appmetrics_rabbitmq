using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppOwinAppMetrics.Middlewares.Metrics.Helper
{
    public interface IRabbitMQHelper
    {
        ConnectionFactory GetConnectionFactory();
        IConnection CreateConnection(ConnectionFactory connectionFactory);
        EventingBasicConsumer CreateConsumer(IConnection connection);
        QueueDeclareOk CreateQueue(string queueName, IConnection connection);
        void WriteMessageOnQueue(string message, string queueName, IConnection connection);
        void ReceiveMessageFromQueue(string queueName, EventingBasicConsumer eventing, IConnection connection);
    }
}