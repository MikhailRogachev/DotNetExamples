using AutoMapperChainedApp.Models;
using AutoMapperChainedApp.Pipeline.Common.Dto;
using nzDto = AutoMapperChainedApp.Pipeline.NZ.Dto;
using usDto = AutoMapperChainedApp.Pipeline.US.Dto;
using System.Runtime.CompilerServices;

namespace AutoMapperChainedApp.Pipeline.Extensions
{
    public static class Sap68AppAreaHelpers
    {
        public static ApplicationAreaItem GetSender()
        {
            return new ApplicationAreaItem
            {
                LogicalId = new Body("DF-APAC", string.Empty)
            };
        }

        public static IEnumerable<ApplicationAreaItem> GetReceiver()
        {
            return new List<ApplicationAreaItem>()
            {
                new ApplicationAreaItem
                {
                    LogicalId = new Body("Avnet", string.Empty)
                }
            };
        }

        public static Type GetHeaderType(this OrderHeader order)
        {
            if (order.Customer.Country == "NZ")
                return typeof(nzDto.Header);
            else if (order.Customer.Country == "US")
                return typeof(usDto.Header);

            return typeof(Header);
        }

        public static Type GetOrderLineType(this OrderLine line)
        {
            var product = line.Products.FirstOrDefault(p => p.SourceType == "SAP68");

            if (product?.ManufacturerCountry == "NZ")
                return typeof(nzDto.SalesOrderLine);
            else if (product?.ManufacturerCountry == "US")
                return typeof(usDto.SalesOrderLine);

            return typeof(SalesOrderLine);
        }
    }
}
