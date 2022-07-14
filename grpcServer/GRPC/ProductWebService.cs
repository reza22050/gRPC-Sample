using Grpc.Core;
using grpcServer.Protos;

namespace grpcServer.GRPC
{
    public class ProductWebService: ProductService.ProductServiceBase
    {
        static List<Product> Products = new List<Product>()
        {
            new Product(){ Brand = "LG", Name = "TVx54", Price = 465000}
        };
        public override Task<ResponseAddProduct> AddNewProduct(RequestAddProductDto request, ServerCallContext context)
        {
            Products.Add(new Product()
            {
                Price  = request.Price, 
                Brand = request.Brand, 
                Name = request.Name,
            });

            Console.WriteLine($"Price: {request.Price}");
            Console.WriteLine($"Brand: {request.Brand}");
            Console.WriteLine($"Name: {request.Name}");

            return Task.FromResult(new ResponseAddProduct() { IsSuccess = true });
        }

        public override Task<ResponseAllProduct> GetAllProduct(RequestAllProduct request, ServerCallContext context)
        {
            ResponseAllProduct response = new ResponseAllProduct();
            foreach (var item in Products)
            {
                response.Items.Add(new ProductItem()
                {
                    Brand = item.Brand,
                    Name = item.Name, 
                    Price = item.Price,
                });
            }
            return Task.FromResult(response);
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
    }
}
