using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Infrastructure.TypeMetrics
{
    public class GaugeMetrics : IGaugeMetrics
    {
        public double ConvertBytesToGigaBytes(double value)
        {
            return (value / (1024* 1024 * 1024));
        }

        public double ConvertBytesToMegaBytes(double value)
        {
            return Math.Round(value / 1024d / 1024d, 2);
        }

        public string TotalPhysicalMemoryGB(ulong value)
        {
            return ConvertBytesToGigaBytes(value).ToString("0.##");
        }

        public double CalculateCpuUsage(double currentTotalProcessorTimeMS, double lastTotalProcessorTimeMS, DateTime currentDate, DateTime lastDate, double processorCount)
        {
            double cpuUsage = (currentTotalProcessorTimeMS - lastTotalProcessorTimeMS) / currentDate.Subtract(lastDate).TotalMilliseconds / processorCount;

            cpuUsage *= 100;

            return Math.Round(cpuUsage, 2);
        }
    }
}
