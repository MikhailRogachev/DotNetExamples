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
                .ForMember(d => d.Header, s => s.MapFrom<HeaderResolver>());

            CreateMap<OrderHeader, Header>()
                .ForMember(d => d.Method, s => s.MapFrom(r => "Main Header"));

            CreateMap<OrderHeader, ApplicationArea>()
                .ForMember(d => d.Sender, s => s.MapFrom(r => Sap68AppAreaHelpers.GetSender()))
                .ForMember(d => d.Receiver, s => s.MapFrom(r => Sap68AppAreaHelpers.GetReceiver()));

            CreateMap<OrderHeader, DataArea>()
                .ForMember(d => d.SalesOrders, s => s.MapFrom(r => new List<OrderHeader>() { r }));

            CreateMap<OrderHeader, SalesOrder>()
                .ForMember(d => d.SalesOrderType, s => s.MapFrom(r => "order - " + r.OrderType))
                .ForMember(d => d.Lines, s => s.MapFrom((src, dest, member, context) => GetOrderLines(src, dest, member, context)));
             

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

        private IList<SalesOrderLine> GetOrderLines(
            OrderHeader source, 
            SalesOrder destination, 
            IList<SalesOrderLine> member,
            ResolutionContext context)
        {
            if(member == null)
                member = new List<SalesOrderLine>();

            foreach(var line in source.Lines)
            {
                Type lineType = line.GetOrderLineType();
                var lineItem = context.Mapper.Map(line, typeof(OrderLine), lineType);

                member.Add((SalesOrderLine)lineItem);
            }

            return member;
        }
    }
}
