using FluentAssertions;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Moq;
using ProductGrpc.Protos;
using ProductGrpc.Services;

namespace ProductGrpcTests.Services
{
    public class GetProductTests : ProductTests
    {

        [Fact]
        public async Task GetProduct_RetunProduct()
        {
            var productId = 1;
            var service = new ProductService(Context, Mapper, new Mock<ILogger<ProductService>>().Object);
            var product = await service.GetProduct(
                new GetProductRequest { ProductId = productId }, 
                new Mock<ServerCallContext>().Object);

            product.Should().NotBeNull();
            product.ProductId.Should().Be(productId);
            product.Name.Should().Be("Mi10T");
        }

        [Fact]
        public void GetProduct_Exception()
        {
            var service = new ProductService(Context, Mapper, new Mock<ILogger<ProductService>>().Object);
            var request = new GetProductRequest { ProductId = 100000 };
            var serverCallContext = new Mock<ServerCallContext>().Object;

            FluentActions.Invoking(() => service.GetProduct(request, serverCallContext))
                .Should().ThrowAsync<RpcException>();
        }
    }
}
