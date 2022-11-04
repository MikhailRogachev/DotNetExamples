using System.Text.Json.Serialization;

namespace AutoMapperChainedApp.Pipeline.Common.Dto
{
    public class Classification
    {
        [JsonPropertyName("@type")]
        public string ItemCategory { get; set; }

        [JsonPropertyName("avt:Codes")]
        public Body Code { get; set; }
    }
}
