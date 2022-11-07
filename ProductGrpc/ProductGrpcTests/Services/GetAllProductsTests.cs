using FluentAssertions;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Moq;
using ProductGrpc.Data;
using ProductGrpc.Protos;
using ProductGrpc.Services;

namespace ProductGrpcTests.Services
{
    public class GetAllProductsTests : ProductTests
    {

        [Fact()]
        public async Task GetAllProducts_Return()
        {
            var serverStreamWriter = new Mock<IServerStreamWriter<ProductModel>>();
            var productsCount = Context.Products.Count();
            var service = new ProductService(Context, Mapper, new Mock<ILogger<ProductService>>().Object);

            await service.GetAllProducts(
                new GetAllProductsRequest(), 
                serverStreamWriter.Object,
                new Mock<ServerCallContext>().Object);

            serverStreamWriter.Verify(p => p.WriteAsync(It.IsAny<ProductModel>()), Times.Exactly(productsCount));            
        }

        [Fact]
        public void GetAllProducts_Exception()
        {
            var context = new ProductsContext();
            var service = new ProductService(context, Mapper, new Mock<ILogger<ProductService>>().Object);

            FluentActions.Invoking(() => service.GetAllProducts(
                new GetAllProductsRequest(),
                new Mock<IServerStreamWriter<ProductModel>>().Object,
                new Mock<ServerCallContext>().Object)).Should().ThrowAsync<RpcException>();
        }
    }
}
