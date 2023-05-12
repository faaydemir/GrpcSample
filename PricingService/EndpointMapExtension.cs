public static class EndpointMapExtension
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        app.MapGet("/{productId}/price",
            async (int productId, IPricingManager PricingManager) =>
            {
                return await PricingManager.GetPrice(productId);
            });

        app.MapPost("/{productId}/price",
            async (int productId, UpdatePriceRequest addPricingRequest, IPricingManager PricingManager) =>
            {
                await PricingManager.SetPrice(productId, addPricingRequest.Price);
            });

        return app;
    }
}

record UpdatePriceRequest(int Price);