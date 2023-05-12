public static class EndpointMapExtension
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        app.MapGet("/product/{productId}",
            async (int productId, IMerchantManager merchantService) =>
            {
                return await merchantService.GetProduct(productId);
            });

        app.MapPut("/product/{productId}/price",
            async (int productId, UpdatePriceRequest price, IMerchantManager merchantService) =>
            {
                await merchantService.UpdatePrice(productId, price.Price);
            });

        app.MapPut("/product/{productId}/stock",
            async (int productId, AddStockRequest stock, IMerchantManager merchantService) =>
            {
                return await merchantService.AddStock(productId, stock.Stock);
            });

        return app;
    }
}

record UpdatePriceRequest(int Price);
record AddStockRequest(int Stock);