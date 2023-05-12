public class PricingManager : IPricingManager
{
    readonly Dictionary<int, int> priceByProductId;

    public PricingManager()
    {
        priceByProductId = new Dictionary<int, int>();

        var random = new Random();
        for (int i = 0; i < 1000; i++)
        {
            priceByProductId[i] = random.Next(1, 1000);
        }
    }

    public Task<ProductPrice> GetPrice(int productId)
    {
        if (!priceByProductId.TryGetValue(productId, out int price))
            throw new ProductNotFoundException(productId);

        return Task.FromResult(new ProductPrice(productId, price));
    }

    public Task SetPrice(int productId, int price)
    {
        if (price <= 0) throw new PriceCantBeNegativeException(price);
        priceByProductId[productId] = price;
        return Task.CompletedTask;
    }
}

public class PriceCantBeNegativeException : Exception
{
    public PriceCantBeNegativeException(int price)
        : base($"PriceCantBeNegative. Given {price}") { }
}

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(int productId)
        : base($"ProductNotFound. Given {productId}") { }
}