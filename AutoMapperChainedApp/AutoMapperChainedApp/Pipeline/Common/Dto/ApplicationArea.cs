using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AutoMapperChainedApp.Pipeline.Common.Dto
{
    public class ApplicationArea
    {
        /// <summary>
        /// MapingInfo: body value for the item in this collection
        /// must be hardcoded = Avnet
        /// </summary>
        [JsonPropertyName("avt:Receiver")]
        public IList<ApplicationAreaItem> Receiver { get; set; }

        /// <summary>
        /// MapingInfo: body value for the item in this collection
        /// must be hardcoded = DF-APAC
        /// </summary>
        [JsonPropertyName("avt:Sender")]
        public ApplicationAreaItem Sender { get; set; }
    }
}
