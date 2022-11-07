using AutoMapper;
using ProductGrpc.Automapper;
using ProductGrpc.Data;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace ProductGrpcTests.Services
{
    public class ProductTests
    {
        public IMapper Mapper => new MapperConfiguration(cfg => cfg.AddProfile<ProductModelProfile>()).CreateMapper();

        public ProductsContext Context
        {
            get
            {
                var context = new ProductsContext();
                ProductsContextSeed.Seed(context);

                return context;
            }
        }
    }
}
