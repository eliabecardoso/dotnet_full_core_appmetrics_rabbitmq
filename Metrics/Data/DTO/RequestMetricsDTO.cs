using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Data.DTO
{
    public class RequestMetricsDTO
    {
        public string Client { get; set; }
        public string Environment { get; set; }
        public string Application { get; set; }

        public string Endpoint { get; set; }
        public string Method { get; set; }
        public string EndpointMethod { get; set; }
        public string UserCall { get; set; }
        public int StatusCode { get; set; }

        public long RequestTime { get; set; }
        public long ResponseTime { get; set; }

        public Int64 UniqueTime { get; set; }
    }
}
