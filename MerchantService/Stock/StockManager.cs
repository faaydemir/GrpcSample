public class StockManager : IStockManager
{
    private readonly Dictionary<int, int> stockByProductId;

    public StockManager()
    {
        stockByProductId = new Dictionary<int, int>();
        var random = new Random();
        for (var i = 0; i < 1000; i++) stockByProductId[i] = random.Next(1, 100);
    }

    public Task<ProductStock> AddStock(int productId, int count)
    {
        int currentStock = 0;
        stockByProductId.TryGetValue(productId, out currentStock);
        stockByProductId[productId] = currentStock + count;

        return Task.FromResult(new ProductStock(productId, stockByProductId[productId]));
    }

    public Task<ProductStock> GetStock(int productId)
    {
        int currentStock = 0;
        stockByProductId.TryGetValue(productId, out currentStock);
        return Task.FromResult(new ProductStock(productId, currentStock));
    }
}