using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Data
{
    public class RequestMetrics
    {
        public const string Name = "requestmetrics";

        public string Id { get; set; }
        public DateTime Timestamp => DateTime.Now;
        public string Client { get; set; }
        public string Environment { get; set; }
        public string Application { get; set; }

        public string Endpoint { get; set; }
        public string Method { get; set; }
        public string EndpointMethod { get; set; }
        public string UserCall { get; set; }
        public int StatusCode { get; set; }
        public double RequestTime { get; set; }
        public double ResponseTime { get; set; }
    }
}
