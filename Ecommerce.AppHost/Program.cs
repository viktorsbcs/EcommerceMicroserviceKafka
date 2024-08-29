using Microsoft.AspNetCore.Builder;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);
        
        var orderService = builder.AddProject<Projects.Ecommerce_OrderService>("apiservice-product");
        var productService = builder.AddProject<Projects.Ecommerce_ProductService>("apiservice-order");
        builder.AddProject<Projects.Ecommerce_Web>("webfrontend")
            .WithReference(orderService)
            .WithReference(productService);
        builder.Build().Run();
    }
}