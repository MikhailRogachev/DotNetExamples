using ProductGrpc.Data;
using ProductGrpc.Services;

static void SeedDatabase(IHost host)
{
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;
    var productsContext = services.GetRequiredService<ProductsContext>();

    ProductsContextSeed.Seed(productsContext);
}

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc(options =>
{
    options.EnableDetailedErrors = true;
});

builder.Services.AddDbContext<ProductsContext>();
builder.Services.AddGrpcReflection();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ProductService>();

// Configure Environment
IWebHostEnvironment env = app.Environment;

if(env.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

SeedDatabase(app);
app.Run();
