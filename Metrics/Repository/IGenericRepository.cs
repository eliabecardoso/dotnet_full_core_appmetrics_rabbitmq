using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        void Store(T entity);
    }
}
