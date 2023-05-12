using ProtoBuf.Grpc;

public class StockServiceGrpc : IStockServiceGrpc
{
    private readonly IStockManager stockManager;

    public StockServiceGrpc(IStockManager stockManager)
    {
        this.stockManager = stockManager;
    }

    public async Task<GetStockResponse> AddStock(AddStockRequest request, CallContext context = default)
    {
        var productStock = await stockManager.AddStock(request.ProductId, request.Count);
        return new GetStockResponse()
        {
            ProductId = productStock.ProductId,
            Stock = productStock.Stock,
        };
    }

    public async Task<GetStockResponse> GetStock(GetStockRequest request, CallContext context = default)
    {
        var productStock = await stockManager.GetStock(request.ProductId);
        return new GetStockResponse()
        {
            ProductId = productStock.ProductId,
            Stock = productStock.Stock,
        };
    }
}