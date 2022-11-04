using AutoMapper;
using AutoMapperChainedApp.Models;
using AutoMapperChainedApp.Pipeline.Common.Dto;
using AutoMapperChainedApp.Pipeline.Extensions;

namespace AutoMapperChainedApp.Pipeline.Common.Profiles
{
    public class OrderProfile : Profile
    {
        public const string OrderHeader = "OrderHeader";
        private readonly string _productCategory = "SAP68";

        public OrderProfile()
        {
            CreateMap<OrderHeader, ErpRequest>()
                .ForMember(d => d.ProcessSalesOrder, s => s.MapFrom(r => r));

            CreateMap<OrderHeader, ProcessSalesOrder>()
                .ForMember(d => d.ApplicationArea, s => s.MapFrom(r => r))
                .ForMember(d => d.DataArea, s => s.MapFrom(r => r))
                .ForMember(d => d.Header, s => s.MapFrom(r => r));

            CreateMap<OrderHeader, Header>()
                .ForMember(d => d.BusinessEntity, s => s.MapFrom(r => "ATS"))
                .ForMember(d => d.Direction, s => s.MapFrom(r => "INBOUND"))
                .ForMember(d => d.IsFullyPopulated, s => s.MapFrom(r => "NO"))
                .ForMember(d => d.Method, s => s.MapFrom(r => "REQUEST"))
                .ForMember(d => d.Noun, s => s.MapFrom(r => "PAYABLE"))
                .ForMember(d => d.PubSystemId, s => s.MapFrom(r => "DSR"))
                .ForMember(d => d.Region, s => s.MapFrom(r => r.Customer.Country))
                .ForMember(d => d.ResponderProcessId, s => s.MapFrom(r => "Common " + r.Customer.Country))
                .ForMember(d => d.Verb, s => s.MapFrom(r => "ADD"));

            CreateMap<OrderHeader, ApplicationArea>()
                .ForMember(d => d.Sender, s => s.MapFrom(r => Sap68AppAreaHelpers.GetSender()))
                .ForMember(d => d.Receiver, s => s.MapFrom(r => Sap68AppAreaHelpers.GetReceiver()));

            CreateMap<OrderHeader, DataArea>()
                .ForMember(d => d.SalesOrders, s => s.MapFrom(r => new List<OrderHeader>() { r }));

            CreateMap<OrderHeader, SalesOrder>()
                .ForMember(d => d.SalesOrderType, s => s.MapFrom(r => "order - " + r.OrderType))
                .ForMember(d => d.Lines, s => s.Ignore())
                .AfterMap((src, dest) =>
                {
                    if (dest.Lines == null)
                        dest.Lines = new List<SalesOrderLine>();
                });

            CreateMap<OrderLine, SalesOrderLine>()
                .ForMember(d => d.LineNumber, s => s.MapFrom(r => new Body(r.LineNumber, string.Empty)))
                .ForMember(d => d.Currency, s => s.MapFrom(r => r.Currency))
                .ForMember(d => d.Quantity, s => s.MapFrom(r => r.Quantity))
                .ForMember(d => d.Price, s => s.MapFrom(r => r.Price))
                .ForMember(d => d.Item, s => s.MapFrom(r => GetItem(r)));
        }

        private Item GetItem(OrderLine source)
        {
            var product = source.Products.First(p => p.SourceType == _productCategory);
            return new Item
            {
                Classifications = new List<Classification>
                {
                    new Classification{ItemCategory = _productCategory, Code = new Body(product.ProductId, product.Manufacturer)}
                },
                CustomerItemId = product.ProductId
            };
        }
    }
}
