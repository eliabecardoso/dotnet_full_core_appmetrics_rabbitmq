using Metrics.Data;
using Metrics.Data.DTO;
using Metrics.Repository;
using Newtonsoft.Json;
using Unity;

namespace Metrics.Service
{
    public class RequestMetricsService : IRequestMetricsService
    {
        [Dependency]
        public IRequestMetricsRepository _requestMetricsRepository;

        public void Store(string message)
        {
            var requestDTO = JsonConvert.DeserializeObject<RequestMetricsDTO>(message);

            var db = new RequestMetrics
            {
                Client = requestDTO.Client,
                Environment = requestDTO.Environment,
                Application = requestDTO.Application,
                Endpoint = requestDTO.Endpoint,
                Method = requestDTO.Method,
                EndpointMethod = requestDTO.EndpointMethod,
                UserCall = requestDTO.UserCall,
                StatusCode = requestDTO.StatusCode,
                RequestTime = requestDTO.RequestTime,
                ResponseTime = requestDTO.ResponseTime,
            };

            _requestMetricsRepository.Store(db);
        }
    }
}
