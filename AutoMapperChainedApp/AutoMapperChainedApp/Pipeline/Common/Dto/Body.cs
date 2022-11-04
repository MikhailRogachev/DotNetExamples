using System.Text.Json.Serialization;

namespace AutoMapperChainedApp.Pipeline.Common.Dto
{
    public class Body
    {
        [JsonPropertyName("*body")]
        public string Value { get; set; }

        [JsonPropertyName("@name")]
        public string Name { get; set; }

        public Body(string value, string name)
        {
            Name = name;
            Value = value;
        }
    }
}
