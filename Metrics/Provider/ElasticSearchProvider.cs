using Elasticsearch.Net;
using Metrics.Data;
using Nest;
using System;
using System.Collections.Generic;

namespace Metrics.Provider
{
    public class ElasticSearchProvider : IElasticSearchProvider
    {
        public static string hostname = "http://localhost:9200/";
        public List<string> _indexes { get; }

        public ElasticSearchProvider()
        {
            _indexes = new List<string>
            {
                RequestMetrics.Name,
                ApplicationMetrics.Name
            };

            CreateIndexes();
        }

        private ConnectionSettings ConfigClientConnection()
        {
            //Uri node; //For 1 DataStore ElasticSearch
            ConnectionSettings connSettings;
            StaticConnectionPool connPool;

            //Cluster's Address - (N) nodes for fail over
            var nodes = new List<Node>
            {
                new Node(new Uri(hostname)),
                //new Uri(),
            };

            connPool = new StaticConnectionPool(nodes);
            connSettings = new ConnectionSettings(connPool);
   

            return connSettings;
        }

        public ElasticClient ESClient()
        {
            ElasticClient elasticClient = new ElasticClient(ConfigClientConnection());

            return elasticClient;
        }

        public void CreateIndexes()
        {
            var elasticClient = ESClient();

            var indexConfig = new IndexState
            {
                Settings = new IndexSettings { NumberOfReplicas = 1, NumberOfShards = 2 }
            };

            _indexes.ForEach(index =>
            {
                if (!elasticClient.IndexExists(index).Exists)
                    switch (index)
                    {
                        case RequestMetrics.Name:
                            var response = elasticClient.CreateIndex(index, c => c
                            .InitializeUsing(indexConfig)
                            .Mappings(m => m.Map<RequestMetrics>(mp => mp.AutoMap())));
                            break;

                        case ApplicationMetrics.Name:
                            elasticClient.CreateIndex(index, c => c
                               .InitializeUsing(indexConfig)
                               .Mappings(m => m.Map<ApplicationMetrics>(mp => mp.AutoMap())));
                            break;
                    }
            });

        }
    }
}
