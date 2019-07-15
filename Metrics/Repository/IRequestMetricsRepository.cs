using Metrics.Data;

namespace Metrics.Repository
{
    public interface IRequestMetricsRepository
    {
        void Store(RequestMetrics db);
    }
}
