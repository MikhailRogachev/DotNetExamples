using FluentAssertions;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Moq;
using ProductGrpc.Protos;
using ProductGrpc.Services;

namespace ProductGrpcTests.Services
{
    public class DeleteProductTests : ProductTests
    {
        [Fact]
        public async Task DeleteProduct_Success()
        {
            var count = Context.Products.Count();
            var request = new DeleteProductRequest
            {
                ProductId = 3
            };

            var service = new ProductService(Context, Mapper, new Mock<ILogger<ProductService>>().Object);
            var response = await service.DeleteProduct(request, new Mock<ServerCallContext>().Object);

            response.Success.Should().BeTrue();
            Context.Products.Should().HaveCount(count - 1);
        }

        [Fact]
        public void DeleteProduct_Exception()
        {
            var service = new ProductService(Context, Mapper, new Mock<ILogger<ProductService>>().Object);

            FluentActions.Invoking(() => service.DeleteProduct(new DeleteProductRequest
            {
                ProductId = 203,
            }, new Mock<ServerCallContext>().Object)).Should().ThrowAsync<RpcException>();
        }
    }
}
