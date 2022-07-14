// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using grpcServer.Protos;

Console.WriteLine("Hello, World!");

var channel = GrpcChannel.ForAddress("https://localhost:7296/");
var productClient = new ProductService.ProductServiceClient(channel);

var response = productClient.AddNewProduct(new RequestAddProductDto()
{
     Brand = "Apple", 
     Name = "iPhone14",
      Price = 986000
});

Console.WriteLine($"IsSuccess = {response.IsSuccess}");
Console.ReadKey();