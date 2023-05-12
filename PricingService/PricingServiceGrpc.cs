using Grpc.Core;
using Pricing;

public class PricingServiceGrpc : PricingService.PricingServiceBase
{
    private readonly IPricingManager pricingManager;

    public PricingServiceGrpc(IPricingManager pricingManager)
    {
        this.pricingManager = pricingManager;
    }

    public override async Task<GetPriceResponse> GetPrice(GetPriceRequest request, ServerCallContext context)
    {
        var productPrice = await pricingManager.GetPrice(request.ProductId);
        return new GetPriceResponse()
        {
            Price = productPrice.Price,
            ProductId = request.ProductId,
        };
    }

    public override async Task<SetPriceResponse> SetPrice(SetPriceRequest request, ServerCallContext context)
    {
        await pricingManager.SetPrice(request.ProductId, request.Price);
        return new SetPriceResponse();
    }
}