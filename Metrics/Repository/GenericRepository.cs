using Metrics.Provider;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Metrics.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        [Dependency]
        IElasticSearchProvider _elasticSearchProvider;

        public void Store(T entity)
        {
            _elasticSearchProvider
                .ESClient()
                .Index(entity, i => i
                .Index(entity.GetType().Name));
        }
    }
}
