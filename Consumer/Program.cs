using AppOwinAppMetrics.Middlewares.Metrics.DI;
using AppOwinAppMetrics.Middlewares.Metrics.Helper;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Unity;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var container = UnityConfig.GetMainContainer();
            var rabbitMQHelper = container.Resolve<IRabbitMQHelper>();


            try
            {
                using (var connection = rabbitMQHelper.CreateConnection(rabbitMQHelper.GetConnectionFactory()))
                {
                    rabbitMQHelper.CreateQueue("RequestMetrics", connection);

                    var consumerRequest = rabbitMQHelper.CreateConsumer(connection);

                    consumerRequest.Received += (model, ea) =>
                        {
                            var body = ea.Body;

                            var message = Encoding.UTF8.GetString(body);

                            //JsonConvert.DeserializeObject<ApplicationMetricsDataStore>(message);

                            Console.WriteLine($"[x] Received Request \n {message}");
                        };

                        rabbitMQHelper.ReceiveMessageFromQueue("RequestMetrics", consumerRequest, connection);

                    //

                    rabbitMQHelper.CreateQueue("ApplicationMetrics", connection);

                    var consumerApplication = rabbitMQHelper.CreateConsumer(connection);

                        consumerApplication.Received += (model, ea) =>
                        {
                            var body = ea.Body;

                            var message = Encoding.UTF8.GetString(body);

                            //JsonConvert.DeserializeObject<ApplicationMetricsDataStore>(message);

                            Console.WriteLine($"[x] Received Application \n {message}");
                        };

                        rabbitMQHelper.ReceiveMessageFromQueue("ApplicationMetrics", consumerApplication, connection);
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Metrics Error");
                Console.WriteLine(ex.Message);
                Console.WriteLine("--------------");
            }
        }
    }
}
