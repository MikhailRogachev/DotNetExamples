using CustomTypeDesirialization.JsonConverters;
using System.Text.Json.Serialization;

namespace CustomTypeDesirialization.Models
{
    [JsonConverter(typeof(StringClassConverter<VendorGroup>))]
    public class VendorGroup
    {
        public string VendorName { get; set; }

        public VendorGroup()
        {
        }

        public VendorGroup(string vendorName)
        {
            VendorName = vendorName;
        }

        public override string ToString()
        {
            return VendorName;
        }
    }
}
