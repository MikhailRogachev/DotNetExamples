using System.Text.Json.Serialization;
using commonDto = AutoMapperChainedApp.Pipeline.Common.Dto;

namespace AutoMapperChainedApp.Pipeline.NZ.Dto
{
    public class ProcessSalesOrder : commonDto.ProcessSalesOrder
    {
        [JsonPropertyName("avt:DataArea")]
        public new DataArea DataArea { get; set; }

        [JsonPropertyName("udmHeader")]
        public new Header Header { get; set; }
    }
}
