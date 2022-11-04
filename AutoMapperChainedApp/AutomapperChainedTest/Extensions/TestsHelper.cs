using AutoMapperChainedApp.Models;
using Newtonsoft.Json;
using commonDto = AutoMapperChainedApp.Pipeline.Common.Dto;
using nzDto = AutoMapperChainedApp.Pipeline.NZ.Dto;
using System.Runtime.CompilerServices;

namespace AutomapperChainedTest.Extensions
{
    public static class TestsHelper
    {
        public static OrderHeader GetOrderSource(string fileName)
        {
            string json = File.ReadAllText("Source/" + fileName);
            return JsonConvert.DeserializeObject<OrderHeader>(json);
        }

        public static Type GetHeaderType(this OrderHeader source)
        {
            if (source.Customer.Country == "NZ")
                return typeof(nzDto.Header);


            return typeof(commonDto.Header);
        }

        //public static Type GetOrderType(this OrderHeader source)
        //{
        //    if (source.Customer.Country == "NZ")
        //        return typeof(nzDto.ErpRequest);


        //    return typeof(commonDto.ErpRequest);
        //}

        public static Type GetOrderLineType(this OrderLine source)
        {
            var product = source.Products.FirstOrDefault(p => p.SourceType == "SAP68");

            if (product?.ManufacturerCountry == "NZ")
                return typeof(commonDto.SalesOrderLine);

            return typeof(commonDto.SalesOrderLine);
        }

        public static object GetObjectValue(this object src, string propertyName)
        {
            var property = src.GetType().GetProperty(propertyName);

            return property != null? property.GetValue(src) : null;
        }

        /// <summary>
        /// https://stackoverflow.com/questions/4194033/adding-items-to-listt-using-reflection
        /// 
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="lineDto"></param>
        public static void AddLine(object destination, object lineDto)
        {
            var property = destination.GetType();





        }
    }
}
