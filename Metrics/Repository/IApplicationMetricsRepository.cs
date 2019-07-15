using Metrics.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Repository
{
    public interface IApplicationMetricsRepository
    {
        void Store(ApplicationMetrics db);

    }
}
