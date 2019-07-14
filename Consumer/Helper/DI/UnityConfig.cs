using AppOwinAppMetrics.Middlewares.Metrics.Helper;
using Unity;

namespace AppOwinAppMetrics.Middlewares.Metrics.DI
{
    public static class UnityConfig
    {
        public static UnityContainer GetMainContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IRabbitMQHelper, RabbitMQHelper>();

            return container;
        }
    }
}