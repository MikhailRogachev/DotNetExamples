using System.Text.Json.Serialization;

namespace AutoMapperChainedApp.Pipeline.Common.Dto
{
    public class Note
    {
        [JsonPropertyName("*body")]
        public string NoteId { get; set; }

        [JsonPropertyName("@type")]
        public string NoteType { get; set; }
    }
}
