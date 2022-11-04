using AutoMapper;
using commonDto = AutoMapperChainedApp.Pipeline.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapperChainedApp.Models;

namespace AutoMapperChainedApp.Pipeline.Extensions
{
    public class HeaderResolver : IValueResolver<OrderHeader, commonDto.ProcessSalesOrder, commonDto.Header>
    {
        public commonDto.Header Resolve(OrderHeader source, 
            commonDto.ProcessSalesOrder destination, 
            commonDto.Header destMember, 
            ResolutionContext context)
        {
            Type headerType = source.GetHeaderType();
            var header = context.Mapper.Map(source, typeof(OrderHeader), headerType);

            return (commonDto.Header)header;
        }
    }
}
