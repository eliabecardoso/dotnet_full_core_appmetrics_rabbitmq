using Metrics.Data;
using Metrics.Provider;
using Unity;

namespace Metrics.Repository
{
    public class ApplicationMetricsRepository : IApplicationMetricsRepository
    {
        [Dependency]
        public IElasticSearchProvider _repository;

        public void Store(ApplicationMetrics db)
        {
            var response = _repository
                .ESClient().Index(db, s => s.Index(ApplicationMetrics.Name));
        }

    }
}
