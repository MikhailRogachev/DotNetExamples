using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutoMapperChainedApp.Pipeline.Common.Dto
{
    public class ApplicationAreaItem
    {
        [JsonPropertyName("avt:LogicalID")]
        public Body LogicalId { get; set; }
    }
}
