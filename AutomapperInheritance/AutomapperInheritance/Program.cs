
using AutoMapper;
using AutomapperInheritance.Input;
using AutomapperInheritance.Profiles;

var _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<ProductProfile>()));
var _products = InputSeed.GetProductsCollection();


foreach(var product in _products)
{
    var type = product.GetProductType();
    var item = _mapper.Map(product, typeof(InputProduct), type);
    Console.WriteLine("Product Type = {0}", item.GetType());
}

Console.ReadKey();