using System.Collections.Generic;
using Newtonsoft.Json;

namespace BVNetwork.Explain
{
    public class ExplainResult
    {
        public bool Ok { get; set; }
        [JsonProperty(PropertyName = "_index")]
        public string Index { get; set; }
        [JsonProperty(PropertyName = "_type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        public bool Matched { get; set; }
        public Explanation Explanation { get; set; }
    }
    public class Explanation
    {
        public double Value { get; set; }
        public string Description { get; set; }
        public IList<Explanation> Details { get; set; }
    }
}