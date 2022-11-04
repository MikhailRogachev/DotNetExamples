using System.Text.Json.Serialization;

namespace AutoMapperChainedApp.Pipeline.Common.Dto
{
    public class ErpRequest
    {
        [JsonPropertyName("avt:ProcessSalesOrder")]
        public ProcessSalesOrder ProcessSalesOrder { get; set; }
    }
}
