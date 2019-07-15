using Metrics.Data;
using Metrics.Data.DTO;
using Metrics.Infrastructure.TypeMetrics;
using Metrics.Repository;
using Newtonsoft.Json;
using Unity;

namespace Metrics.Service
{
    public class ApplicationMetricsService : IApplicationMetricsService
    {
        [Dependency]
        public IGaugeMetrics _gaugeMetrics;

        [Dependency]
        public IApplicationMetricsRepository _applicationMetricsRepository;

        public void Store(string message)
        {
            var applicationDTO = JsonConvert.DeserializeObject<ApplicationMetricsDTO>(message);

            var db = new ApplicationMetrics
            {
                Client = applicationDTO.Client,
                Environment = applicationDTO.Environment,
                Application = applicationDTO.Application,
                ActiveRequests = applicationDTO.ActiveRequests,
                Errors4xx = applicationDTO.Errors4xx,
                Errors5xx = applicationDTO.Errors5xx,
            };

            db.PhysicalMemoryUsageMB = _gaugeMetrics.ConvertBytesToMegaBytes(applicationDTO.PhysicalMemoryUsage);
            db.CpuUsage = _gaugeMetrics.CalculateCpuUsage(applicationDTO.CurrentProcessorTime, applicationDTO.LastTotalProcessorTime
                                                            , applicationDTO.CurrentProcessorDate, applicationDTO.LastProcessorDate
                                                            , applicationDTO.ProcessorCoreCount);

            _applicationMetricsRepository.Store(db);
        }
    }
}
