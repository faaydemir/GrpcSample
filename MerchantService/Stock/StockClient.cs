public class StockClient : IStockManager
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly string STOCK_SERVICE_URL = "https://localhost:5004";
    private HttpClient Client => httpClientFactory.CreateClient();

    public StockClient(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<ProductStock> AddStock(int productId, int count)
    {
        return await Client.Put<ProductStock, AddStockRequest>($"{STOCK_SERVICE_URL}/{productId}/stock/add", new AddStockRequest(count));
    }

    public async Task<ProductStock> GetStock(int productId)
    {
        return await Client.Get<ProductStock>($"{STOCK_SERVICE_URL}/{productId}/stock");
    }
}