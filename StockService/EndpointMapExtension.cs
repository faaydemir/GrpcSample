public static class EndpointMapExtension
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        app.MapGet(
            "/{productId}/stock",
            async (int productId, IStockManager stockManager) =>
            {
                return await stockManager.GetStock(productId);
            }
        );

        app.MapPut(
            "/{productId}/stock/add",
            async (int productId, AddStockRequest addStockRequest, IStockManager stockManager) =>
            {
                return await stockManager.AddStock(productId, addStockRequest.Stock);
            }
        );
        return app;
    }
}

record AddStockRequest(int Stock);