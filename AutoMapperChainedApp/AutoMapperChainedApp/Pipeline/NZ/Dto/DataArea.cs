using System.Text.Json.Serialization;
using commonDto = AutoMapperChainedApp.Pipeline.Common.Dto;

namespace AutoMapperChainedApp.Pipeline.NZ.Dto
{
    public class DataArea : commonDto.DataArea
    {
        [JsonPropertyName("avt:SalesOrder")]
        public new IList<SalesOrder> SalesOrders { get; set; }
    }
}
