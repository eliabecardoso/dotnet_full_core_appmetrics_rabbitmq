using Metrics.Infrastructure.TypeMetrics;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Metrics.Data
{
    public class ApplicationMetrics
    {
        public const string Name = "applicationmetrics";

        public string Id { get; set; }
        public DateTime Timestamp { get { return DateTime.Now; } }
        public string Client { get; set; }
        public string Environment { get; set; }
        public string Application { get; set; }
        
        public int ActiveRequests { get; set; }
        public int Errors4xx { get; set; }
        public int Errors5xx { get; set; }
        public double CpuUsage { get; set; }
        public double PhysicalMemoryUsageMB { get; set; }

    }
   
}
