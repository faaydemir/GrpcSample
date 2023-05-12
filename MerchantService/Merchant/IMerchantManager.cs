public interface IMerchantManager
{
    Task<Product> GetProduct(int product);
    Task<ProductStock> AddStock(int productId, int count);
    Task UpdatePrice(int productId, int price);
}

public record Product(int ProductId, decimal Price, int Stock);