using System.Text.Json.Serialization;

namespace AutoMapperChainedApp.Pipeline.Common.Dto
{
    public class SalesOrderLine
    {
        [JsonPropertyName("avt:Item")]
        public Item Item { get; set; }

        [JsonPropertyName("avt:LineNumber")]
        public Body LineNumber { get; set; }

        [JsonPropertyName("avt:Currency")]
        public string Currency { get; set; }

        [JsonPropertyName("avt:Price")]
        public decimal Price { get; set; }

        [JsonPropertyName("avt:Quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("avt:Note")]
        public IList<Note> Note { get; set; }
    }
}
