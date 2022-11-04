using AutoMapperChainedApp.Models;
using commonProfile = AutoMapperChainedApp.Pipeline.Common.Profiles;
using commonDto = AutoMapperChainedApp.Pipeline.Common.Dto;
using nzDto = AutoMapperChainedApp.Pipeline.NZ.Dto;

namespace AutoMapperChainedApp.Pipeline.NZ.Profiles
{
    public class NzOrderProfile : commonProfile.OrderProfile
    {
        private readonly string _productCategory = "eShop";

        public NzOrderProfile()
        {
            CreateMap<OrderHeader, nzDto.Header>()
                .IncludeBase<OrderHeader, commonDto.Header>()
                .ForMember(d => d.Region, s => s.MapFrom(r => r.Customer.CustomerNumber))
                .ForMember(d => d.ResponderProcessId, s => s.MapFrom(r => "Common " + r.Customer.CustomerNumber))
                .ForMember(d => d.ExtraValue, s => s.MapFrom(r => "ExtraValue"));

            CreateMap<OrderLine, nzDto.SalesOrderLine>()
                .IncludeBase<OrderLine, commonDto.SalesOrderLine>()
                .ForMember(d => d.Item, s => s.MapFrom(r => GetItem(r)))
                .ForMember(d => d.Note, s => s.MapFrom(r => GetNotes(r)));
        }

        private commonDto.Item GetItem(OrderLine source)
        {
            var product = source.Products.First(p => p.SourceType == _productCategory);
            return new commonDto.Item
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

        private IList<commonDto.Note> GetNotes(OrderLine source)
        {
            if (source.Deal == null)
                return new List<commonDto.Note>();

            return new List<commonDto.Note>
            {
                new commonDto.Note{ NoteId = source.Deal.DealId, NoteType = "Discount" }
            };
        }
    }
}
