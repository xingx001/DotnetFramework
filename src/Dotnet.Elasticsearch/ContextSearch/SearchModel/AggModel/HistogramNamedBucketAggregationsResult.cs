using System.Collections.Generic;
using Dotnet.Elasticsearch.ContextSearch.SearchModel.AggModel.Buckets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dotnet.Elasticsearch.ContextSearch.SearchModel.AggModel
{
	public class HistogramNamedBucketAggregationsResult : AggregationResult<HistogramNamedBucketAggregationsResult>
	{
		[JsonProperty("buckets")]
		public NamedBucket Buckets { get; set; }

		[JsonExtensionData]
		public Dictionary<string, JToken> SubAggregations { get; set; }

		public T GetSubAggregationsFromJTokenName<T>(string name)
		{
			return SubAggregations[name].ToObject<T>();
		}

		public T GetSingleMetricSubAggregationValue<T>(string name)
		{
			return SubAggregations[name]["value"].Value<T>();
		}
		public override HistogramNamedBucketAggregationsResult GetValueFromJToken(JToken result)
		{
			return result.ToObject<HistogramNamedBucketAggregationsResult>();
		}
	}
}