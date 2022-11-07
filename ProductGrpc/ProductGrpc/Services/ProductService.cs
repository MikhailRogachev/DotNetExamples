using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using ProductGrpc.Data;
using ProductGrpc.Models;
using ProductGrpc.Protos;

namespace ProductGrpc.Services
{
    public class ProductService : ProductProtoService.ProductProtoServiceBase
    {
        private readonly ProductsContext _productContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(
            ProductsContext productContext, 
            IMapper mapper,
            ILogger<ProductService> logger)
        {
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override Task<Empty> Test(Empty request, ServerCallContext context)
        {
            return base.Test(request, context);
        }

        public override async Task<ProductModel> GetProduct(
            GetProductRequest request, 
            ServerCallContext context
            )
        {
            var product = await _productContext.Products.FindAsync(request.ProductId);

            if(product is null)
            {
                _logger.LogInformation("The product {id} doesn't exist.", request.ProductId);
                throw new RpcException(new Status(StatusCode.NotFound,
                    $"The Product with Id = {request.ProductId} doesn't exist."));
            }

            return _mapper.Map<ProductModel>(product);
        }

        public override async Task GetAllProducts(
            GetAllProductsRequest request, 
            IServerStreamWriter<ProductModel> responseStream, 
            ServerCallContext context
            )
        {
            var products = await _productContext.Products.ToListAsync();

            if(!products.Any())
            {
                _logger.LogInformation("The products collection doesn't exist.");
                throw new RpcException(Status.DefaultCancelled);
            }

            foreach(var product in products)
            {
                await responseStream.WriteAsync(_mapper.Map<ProductModel>(product));
            }            
        }

        public override async Task<ProductModel> AddProduct(
            AddProductRequest request, 
            ServerCallContext context
            )
        {
            if (_productContext.Products.Any(p => p.ProductId == request.Product.ProductId))
            {
                _logger.LogInformation("The Product Id {id} already exists.", request.Product.ProductId);
                throw new RpcException(Status.DefaultCancelled, "The product with this Id already exists.");
            }

            var product = _mapper.Map<Product>(request.Product);

            _productContext.Products.Add(product);
            _ = await _productContext.SaveChangesAsync();

            return _mapper.Map<ProductModel>(product);            
        }

        public override async Task<ProductModel> UpdateProduct(
            UpdateProductRequest request, 
            ServerCallContext context)
        {
            var exists = await _productContext.Products.AnyAsync(p => p.ProductId == request.Product.ProductId);

            if (!exists)
            {
                _logger.LogInformation("The Product Id {id} dosn't exists.", request.Product.ProductId);
                throw new RpcException(new Status(StatusCode.NotFound,
                    $"The Product with Id = {request.Product.ProductId} doesn't exist."));
            }

            var product = _mapper.Map<Product>(request.Product);
            _productContext.Entry(product).State = EntityState.Modified;

            try
            {
                await _productContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }

            return _mapper.Map<ProductModel>(product);
        }

        public override async Task<DeleteProductResponse> DeleteProduct(
            DeleteProductRequest request, 
            ServerCallContext context)
        {
            var product = await _productContext.Products.FirstOrDefaultAsync(p => p.ProductId == request.ProductId);

            if (product == null)
            {
                _logger.LogInformation("The Product Id {id} dosn't exists.", request.ProductId);
                throw new RpcException(new Status(StatusCode.NotFound,
                    $"The Product with Id = {request.ProductId} doesn't exist."));
            }

            _productContext.Products.Remove(product);
            var result = await _productContext.SaveChangesAsync();

            return new DeleteProductResponse { Success = result > 0 };
        }

        public override async Task<InsertBulkProductResponse> InsertBulkProduct(
            IAsyncStreamReader<ProductModel> requestStream, 
            ServerCallContext context)
        {
            while(await requestStream.MoveNext())
            {
                var product = _mapper.Map<Product>(requestStream.Current);
                _productContext.Products.Add(product);
            }

            var count = await _productContext.SaveChangesAsync();

            return new InsertBulkProductResponse { InsertCount = count, Success = count > 0 };
        }
    }
}
