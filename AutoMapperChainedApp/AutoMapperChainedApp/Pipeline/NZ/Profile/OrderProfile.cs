using AutoMapperChainedApp.Models;
using commonProfile = AutoMapperChainedApp.Pipeline.Common.Profiles;
using commonDto = AutoMapperChainedApp.Pipeline.Common.Dto;
using nzDto = AutoMapperChainedApp.Pipeline.NZ.Dto;

namespace AutoMapperChainedApp.Pipeline.NZ.Profiles
{
    public class OrderProfile : commonProfile.OrderProfile
    {
        private readonly string _productCategory = "eShop";

        public OrderProfile()
        {
            CreateMap<OrderHeader, nzDto.ErpRequest>()
                .IncludeBase<OrderHeader, commonDto.ErpRequest>()
                .ForMember(d => d.ProcessSalesOrder, s => s.MapFrom(r => r));

            CreateMap<OrderHeader, nzDto.ProcessSalesOrder>()
                .IncludeBase<OrderHeader, commonDto.ProcessSalesOrder>()
                .ForMember(d => d.Header, s => s.MapFrom(r => r));

            CreateMap<OrderHeader, nzDto.Header>()
                .IncludeBase<OrderHeader, commonDto.Header>()
                .ForMember(d => d.Region, s => s.MapFrom(r => r.Customer.CustomerNumber))
                .ForMember(d => d.ResponderProcessId, s => s.MapFrom(r => "Common " + r.Customer.CustomerNumber))
                .ForMember(d => d.ExtraValue, s => s.MapFrom(r => "ExtraValue"));

            CreateMap<OrderHeader, nzDto.DataArea>()
                .IncludeBase<OrderHeader, commonDto.DataArea>()
                .ForMember(d => d.SalesOrders, s => s.MapFrom(r => new List<OrderHeader>() { r }));

            CreateMap<OrderHeader, nzDto.SalesOrder>()
                .IncludeBase<OrderHeader, commonDto.SalesOrder>();
                //.ForMember(d => d.Lines, s => s.Ignore())
                //.AfterMap((src, dest) =>
                //{
                //    if (dest.Lines == null)
                //        dest.Lines = new List<nzDto.SalesOrderLine>();
                //});

            CreateMap<OrderLine, commonDto.SalesOrderLine>()
                .IncludeBase<OrderLine, commonDto.SalesOrderLine>()
                .ForMember(d => d.Item, s => s.MapFrom(r => GetItem(r)))
                .ForMember(d => d.Note, s => s.MapFrom(r => GetNotes(r)));
        }

        private nzDto.Item GetItem(OrderLine source)
        {
            var product = source.Products.First(p => p.SourceType == _productCategory);
            return new nzDto.Item
            {
                Classifications = new List<commonDto.Classification>
                {
                    new commonDto.Classification
                    {
                        ItemCategory = _productCategory, 
                        Code = new commonDto.Body(product.Manufacturer, product.ManufacturerCountry)}
                },
                CustomerItemId = product.ProductId
            };
        }

        private IList<nzDto.Note> GetNotes(OrderLine source)
        {
            if(source.Deal == null)
                return new List<nzDto.Note>();

            return new List<nzDto.Note>
            {
                new nzDto.Note{ NoteId = source.Deal.DealId, NoteType = "Discount" }
            };            
        }
    }
}
