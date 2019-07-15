using Consumer.DI;
using Consumer.Helper;
using Metrics.Service;
using System;
using System.Text;
using Unity;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting data. (Press any key for exit)");

            var container = UnityConfig.GetMainContainer();
            var rabbitMQHelper = container.Resolve<IRabbitMQHelper>();

            var requestService = container.Resolve<IRequestMetricsService>();
            var applicationService = container.Resolve<IApplicationMetricsService>();


            try
            {
                using (var connection = rabbitMQHelper.CreateConnection(rabbitMQHelper.GetConnectionFactory()))
                using (var channel = connection.CreateModel())
                {
                    rabbitMQHelper.CreateQueue("RequestMetrics", channel);

                    var consumerRequest = rabbitMQHelper.CreateConsumer(channel);

                    consumerRequest.Received += (model, ea) =>
                    {
                        var body = ea.Body;

                        var message = Encoding.UTF8.GetString(body);

                        requestService.Store(message);

                        Console.WriteLine($"[x] Received Request {ea.RoutingKey}");
                    };

                    rabbitMQHelper.ReceiveMessageFromQueue("RequestMetrics", consumerRequest, channel);

                    //

                    rabbitMQHelper.CreateQueue("ApplicationMetrics", channel);

                    var consumerApplication = rabbitMQHelper.CreateConsumer(channel);

                    consumerApplication.Received += (model, ea) =>
                    {
                        var body = ea.Body;

                        var message = Encoding.UTF8.GetString(body);

                        applicationService.Store(message);

                        Console.WriteLine($"[x] Received {ea.RoutingKey}");
                    };

                    rabbitMQHelper.ReceiveMessageFromQueue("ApplicationMetrics", consumerApplication, channel);


                    Console.ReadKey();
                    Console.WriteLine("you sure that? (any key)");
                    Console.ReadKey();

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
