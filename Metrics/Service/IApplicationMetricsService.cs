using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Service
{
    public interface IApplicationMetricsService
    {
        void Store(string message);
    }
}
