public class MerchantManager : IMerchantManager
{
    private readonly IPricingManager priceService;
    private readonly IStockManager stockService;

    public MerchantManager(IStockManager stockService, IPricingManager priceService)
    {
        this.stockService = stockService;
        this.priceService = priceService;
    }

    public async Task<Product> GetProduct(int product)
    {
        var priceAwaiter = priceService.GetPrice(product);
        var stockAwaiter = stockService.GetStock(product);

        return new Product(
            product,
            (await priceAwaiter).Price,
            (await stockAwaiter).Stock
        );
    }

    public async Task<ProductStock> AddStock(int productId, int count)
    {
        return await stockService.AddStock(productId, count);
    }

    public async Task UpdatePrice(int productId, int price)
    {
        await priceService.SetPrice(productId, price);
    }
}