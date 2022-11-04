using System.Text.Json.Serialization;

namespace AutoMapperChainedApp.Pipeline.Common.Dto
{
    public class Item
    {
        [JsonPropertyName("avt:Classification")]
        public IList<Classification> Classifications { get; set; }

        [JsonPropertyName("avt:CustomerItemID")]
        public string CustomerItemId { get; set; }
    }
}
