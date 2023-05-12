using Pricing;
using static Pricing.PricingService;
public class PricingClient : IPricingManager
{
    private readonly PricingServiceClient pricingClient;

    public PricingClient(PricingServiceClient pricingClient)
    {
        this.pricingClient = pricingClient;
    }

    public async Task<ProductPrice> GetPrice(int productId)
    {
        var productPrice = await pricingClient.GetPriceAsync(new GetPriceRequest() { ProductId = productId });
        return new ProductPrice(productPrice.ProductId, productPrice.Price);
    }

    public async Task SetPrice(int productId, int price)
    {
        await pricingClient.SetPriceAsync(new SetPriceRequest() { ProductId = productId, Price = price });
    }
}