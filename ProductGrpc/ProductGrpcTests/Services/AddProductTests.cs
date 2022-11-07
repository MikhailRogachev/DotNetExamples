using FluentAssertions;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Moq;
using ProductGrpc.Protos;
using ProductGrpc.Services;

namespace ProductGrpcTests.Services
{
    public class AddProductTests : ProductTests
    {
        [Fact]
        public async Task AddProductTest_Success()
        {
            var productId = 102;
            var productCount = Context.Products.Count();
            var service = new ProductService(Context, Mapper, new Mock<ILogger<ProductService>>().Object);
            var product = await service.AddProduct(
                new AddProductRequest
                {
                    Product = new ProductModel
                    {
                        ProductId = productId,
                        Name = "New Product",
                        Description = "Product Added in the test",
                        Price = 100.0F,
                        Status = ProductStatus.Low,
                        CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow)
                    }
                },
                new Mock<ServerCallContext>().Object);

            product.Should().NotBeNull();
            product.ProductId.Should().Be(productId);
            Context.Products.Should().HaveCount(productCount + 1);
        }

        [Fact]
        public void AddProductTest_Exception()
        {
            var service = new ProductService(Context, Mapper, new Mock<ILogger<ProductService>>().Object);
            var request = new AddProductRequest
            {
                Product = new ProductModel
                {
                    ProductId = 2,
                    Name = "New Product",
                    Description = "Product Added in the test",
                    Price = 100.0F,
                    Status = ProductStatus.Low,
                    CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow)
                }
            };

            FluentActions.Invoking(() => service.AddProduct(request, new Mock<ServerCallContext>().Object))
                .Should().ThrowAsync<RpcException>();
        }
    }
}
