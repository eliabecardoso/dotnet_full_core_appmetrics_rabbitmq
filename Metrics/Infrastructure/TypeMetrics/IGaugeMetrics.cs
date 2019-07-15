using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Infrastructure.TypeMetrics
{
    public interface IGaugeMetrics
    {
        double ConvertBytesToGigaBytes(double value);

        double ConvertBytesToMegaBytes(double value);

        string TotalPhysicalMemoryGB(ulong value);

        double CalculateCpuUsage(double lastTotalProcessorTime, double currentTotalProcessorTime, DateTime lastDate, DateTime currentDate, double processorCount);
    }
}
