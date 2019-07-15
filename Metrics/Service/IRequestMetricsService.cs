using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Service
{
    public interface IRequestMetricsService
    {
        void Store(string message);
    }
}
