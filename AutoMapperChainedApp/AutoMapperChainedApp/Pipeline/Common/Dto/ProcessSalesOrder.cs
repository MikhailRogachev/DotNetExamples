using System.Text.Json.Serialization;

namespace AutoMapperChainedApp.Pipeline.Common.Dto
{
    public class ProcessSalesOrder
    {
        [JsonPropertyName("avt:ApplicationArea")]
        public ApplicationArea ApplicationArea { get; set; }

        [JsonPropertyName("avt:DataArea")]
        public DataArea DataArea { get; set; }

        [JsonPropertyName("udmHeader")]
        public Header Header { get; set; }
    }
}
