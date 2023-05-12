public interface IStockManager
{
    Task<ProductStock> GetStock(int productId);
    Task<ProductStock> AddStock(int productId, int count);
}

public record ProductStock(int ProductId, int Stock);