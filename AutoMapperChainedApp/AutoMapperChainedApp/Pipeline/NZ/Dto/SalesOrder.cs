using System.Text.Json.Serialization;
using commonDto = AutoMapperChainedApp.Pipeline.Common.Dto;

namespace AutoMapperChainedApp.Pipeline.NZ.Dto
{
    public class SalesOrder : commonDto.SalesOrder
    {
        //[JsonPropertyName("avt:SalesOrderLine")]
        //public new IList<SalesOrderLine> Lines { get; set; }
    }
}
