using FluentAssertions;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Moq;
using ProductGrpc.Protos;
using ProductGrpc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductGrpcTests.Services
{
    public class UpdateProductTests : ProductTests
    {
        [Fact]
        public async Task UpdateProduct_Success()
        {
            var request = new UpdateProductRequest
            {
                Product = new ProductModel
                {
                    ProductId = 2,
                    Name = "Red Wings",
                    Description = "New Red Phone Mi10T - updated",
                    Price = 1699,
                    Status = ProductStatus.Instock,
                    CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow)
                }
            };

            var service = new ProductService(Context, Mapper, new Mock<ILogger<ProductService>>().Object);
            var response = await service.UpdateProduct(request, new Mock<ServerCallContext>().Object);

            response.ProductId.Should().Be(request.Product.ProductId);
            response.Name.Should().Be(request.Product.Name);
            response.Description.Should().Be(request.Product.Description);
            response.Price.Should().Be(request.Product.Price);
        }

        [Fact]
        public void UpdateProduct_Exception()
        {
            var request = new UpdateProductRequest
            {
                Product = new ProductModel
                {
                    ProductId = 202,
                    Name = "Red Wings",
                    Description = "New Red Phone Mi10T - updated",
                    Price = 1699,
                    Status = ProductStatus.Instock,
                    CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow)
                }
            };

            var service = new ProductService(Context, Mapper, new Mock<ILogger<ProductService>>().Object);

            FluentActions.Invoking(() => service.UpdateProduct(request, new Mock<ServerCallContext>().Object))
                .Should().ThrowAsync<RpcException>();




        }

    }
}
