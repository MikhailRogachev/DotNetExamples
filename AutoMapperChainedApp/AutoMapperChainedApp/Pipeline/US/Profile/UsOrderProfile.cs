using commonProfile = AutoMapperChainedApp.Pipeline.Common.Profiles;
using commonDto = AutoMapperChainedApp.Pipeline.Common.Dto;
using usDto = AutoMapperChainedApp.Pipeline.US.Dto;
using AutoMapperChainedApp.Models;

namespace AutoMapperChainedApp.Pipeline.US.Profiles
{
    public class UsOrderProfile : commonProfile.OrderProfile
    {
        public UsOrderProfile()
        {
            CreateMap<OrderHeader, usDto.Header>()
                .IncludeBase<OrderHeader, commonDto.Header>()
                .ForMember(d => d.Region, s => s.MapFrom(r => r.Customer.Country))
                .ForMember(d => d.ResponderProcessId, s => s.MapFrom(r => "Common " + r.ResellerId))
                .ForMember(d => d.ExtraValue, s => s.MapFrom(r => DateTime.Now.ToLongDateString()));

            CreateMap<OrderLine, usDto.SalesOrderLine>()
                .IncludeBase<OrderLine, commonDto.SalesOrderLine>()
                .ForMember(d => d.LineNumber, s => s.MapFrom(r => new commonDto.Body(r.LineNumber, r.LineNumber)));
        }
    }
}
