using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Google.Protobuf.WellKnownTypes;
using ProductGrpc.Models;
using ProductGrpc.Protos;

namespace ProductGrpc.Automapper
{
    public class ProductModelProfile : Profile
    {
        public ProductModelProfile()
        {
            CreateMap<Product, ProductModel>()
                .ForMember(d => d.CreatedTime, s => s.MapFrom(r => Timestamp.FromDateTime(r.CreatedTime)));

            CreateMap<ProductModel, Product>()
                .ForMember(d => d.CreatedTime, s => s.MapFrom(r => r.CreatedTime.ToDateTime()));

            CreateMap<Enums.ProductStatus, ProductStatus>()
                .ConvertUsingEnumMapping(d => d.MapByValue())
                .ReverseMap();
        }
    }
}