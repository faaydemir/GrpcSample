using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

public class StockClient : IStockManager
{
    private IStockServiceGrpc client;
    private readonly string STOCK_SERVICE_URL = "https://localhost:5004";
    public StockClient()
    {
        var channel = GrpcChannel.ForAddress(STOCK_SERVICE_URL);
        client = channel.CreateGrpcService<IStockServiceGrpc>();
    }

    public async Task<ProductStock> AddStock(int productId, int count)
    {
        var currentStock = await client.AddStock(new AddStockRequestGrpc() { ProductId = productId, Count = count });
        return new ProductStock(currentStock.ProductId, currentStock.Stock);
    }

    public async Task<ProductStock> GetStock(int productId)
    {
        var stock = await client.GetStock(new GetStockRequest() { ProductId = productId });
        return new ProductStock(stock.ProductId, stock.Stock);
    }
}