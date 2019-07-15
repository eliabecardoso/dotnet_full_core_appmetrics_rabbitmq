using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Provider
{
    public interface IElasticSearchProvider
    {
        ElasticClient ESClient();
        void CreateIndexes();
    }
}
