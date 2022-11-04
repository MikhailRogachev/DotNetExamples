using System.Text.Json.Serialization;
using commonDto = AutoMapperChainedApp.Pipeline.Common.Dto;

namespace AutoMapperChainedApp.Pipeline.NZ.Dto
{
    public class ErpRequest : commonDto.ErpRequest
    {
        [JsonPropertyName("avt:ProcessSalesOrder")]
        public new ProcessSalesOrder ProcessSalesOrder { get; set; }
    }
}
