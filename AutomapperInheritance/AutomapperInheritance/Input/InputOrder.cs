using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperInheritance.Input
{
    public class InputOrder
    {
        public string Id { get; set; }
        public string OrderNumber { get; set; }
        public string CustomPo { get; set; }
        public EnumOrderStatus CurrentStatus { get; set; }



    }
}
