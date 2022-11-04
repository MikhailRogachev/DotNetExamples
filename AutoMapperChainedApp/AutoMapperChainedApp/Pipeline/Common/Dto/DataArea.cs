using System.Text.Json.Serialization;

namespace AutoMapperChainedApp.Pipeline.Common.Dto
{
    public class DataArea
    {
        [JsonPropertyName("avt:SalesOrder")]
        public IList<SalesOrder> SalesOrders { get; set; }
    }
}
