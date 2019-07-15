using Metrics.Data;
using Metrics.Provider;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Metrics.Repository
{
    public class RequestMetricsRepository : IRequestMetricsRepository
    {
        [Dependency]
        public IElasticSearchProvider _repository;

        public void Store(RequestMetrics db)
        {
            var response = _repository
               .ESClient()
                .Index(db, s => s
                .Index(RequestMetrics.Name));
        }

    }
}
