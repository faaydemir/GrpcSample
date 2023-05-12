public interface IPricingManager
{
    Task<ProductPrice> GetPrice(int productId);
    Task SetPrice(int productId, int price);
}

public record ProductPrice(int ProductId, int Price);