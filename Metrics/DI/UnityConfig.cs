using Metrics.Infrastructure.TypeMetrics;
using Metrics.Provider;
using Metrics.Repository;
using Metrics.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Lifetime;

namespace Metrics.DI
{
    public static class UnityConfig
    {
        public static UnityContainer GetMainContainer()
        {
            var container = new UnityContainer();

            //container.RegisterType<IElasticSearchProvider, ElasticSearchProvider>();

            //container.RegisterType<IGaugeMetrics, GaugeMetrics>();

            //container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>), new SingletonLifetimeManager());
            //container.RegisterType<IApplicationMetricsRepository, ApplicationMetricsRepository>();
            //container.RegisterType<IRequestMetricsRepository, RequestMetricsRepository>();

            //container.RegisterType<IApplicationMetricsService, ApplicationMetricsService>();
            //container.RegisterType<IRequestMetricsService, RequestMetricsService>();

            return container;
        }
    }
}
