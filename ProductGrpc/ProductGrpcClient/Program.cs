using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using ProductGrpc.Protos;

static async Task GetProductRequest(ProductProtoService.ProductProtoServiceClient client)
{
    Console.WriteLine("Get Product call started.");

    var response = await client.GetProductAsync(new GetProductRequest { ProductId = 1 });

    Console.WriteLine("Response: {0}", response);

}

static async Task GetAllProductsRequest(ProductProtoService.ProductProtoServiceClient client)
{
    Console.WriteLine("Get All products call started.");
    using var clientdata = client.GetAllProducts(new GetAllProductsRequest());
    await foreach (var responsedata in clientdata.ResponseStream.ReadAllAsync())
    {
        Console.WriteLine(responsedata);
    }
}

static async Task AddProductRequest(ProductProtoService.ProductProtoServiceClient client)
{
    Console.WriteLine("Add Product method started.");
    var response = await client.AddProductAsync(new AddProductRequest
    {
        Product = new ProductModel
        {
            Name = "Red",
            Description = "New Red Phone Mi10T",
            Price = 699,
            Status = ProductStatus.Instock,
            CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow)
            
        }
    });

    Console.WriteLine("The product added: {0}", response);
}

static async Task UpdateProductsRequest(ProductProtoService.ProductProtoServiceClient client)
{
    Console.WriteLine("Update product call started.");
    var response = await client.UpdateProductAsync(new UpdateProductRequest
    {
        Product = new ProductModel
        {
            ProductId = 1,
            Name = "Red Wings",
            Description = "New Red Phone Mi10T - updated",
            Price = 1699,
            Status = ProductStatus.Instock,
            CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow)

        }
    });

    Console.WriteLine("The product updated: {0}", response);
}

static async Task RemoveProductsRequest(ProductProtoService.ProductProtoServiceClient client)
{
    Console.WriteLine("Delete product call started.");
    var response = await client.DeleteProductAsync(new DeleteProductRequest
    {
        ProductId = 2
    });
    Console.WriteLine("The product deleted. Response: {0}", response.Success.ToString());
}

static async Task InsertBulkAsync(ProductProtoService.ProductProtoServiceClient client)
{
    Console.WriteLine("Insert bulk products call started.");

    using var clientBulk = client.InsertBulkProduct();

    for(int i = 8; i < 25; i++)
    {
        var item = new ProductModel
        {
            Name = $"Red - {i}",
            Description = $"New Red Phone Mi{i * 100}T",
            Price = 699,
            Status = ProductStatus.Instock,
            CreatedTime = Timestamp.FromDateTime(DateTime.UtcNow)
        };

        await clientBulk.RequestStream.WriteAsync(item);
    }

    await clientBulk.RequestStream.CompleteAsync();

    var response = await clientBulk;
    Console.WriteLine($"Status: {response.Success}. Insert count: {response.InsertCount}");
}

using var channel = GrpcChannel.ForAddress("https://localhost:7106");
var client = new ProductProtoService.ProductProtoServiceClient(channel);

// get product by Id
await GetProductRequest(client);
Console.WriteLine(string.Empty);
// get all products
await GetAllProductsRequest(client);
Console.WriteLine(string.Empty);
// add product
await AddProductRequest(client);
Console.WriteLine(string.Empty);
await GetAllProductsRequest(client);
// update product
Console.WriteLine(string.Empty);
await UpdateProductsRequest(client);
await GetAllProductsRequest(client);
// remove product
Console.WriteLine(string.Empty);
await RemoveProductsRequest(client);
await GetAllProductsRequest(client);
// Insert bulk
Console.WriteLine(string.Empty);
await InsertBulkAsync(client);
await GetAllProductsRequest(client);



Console.ReadKey();
