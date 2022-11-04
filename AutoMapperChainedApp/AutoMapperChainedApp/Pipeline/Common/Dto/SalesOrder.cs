using System.Text.Json.Serialization;

namespace AutoMapperChainedApp.Pipeline.Common.Dto
{
    public class SalesOrder
    {
        /// <summary>
        /// MapingInfo: the value for this property is hardcoded and = "order"
        /// </summary>
        [JsonPropertyName("@type")]
        public string SalesOrderType { get; set; }

        [JsonPropertyName("avt:SalesOrderLine")]
        public IList<SalesOrderLine> Lines { get; set; }
    }
}
