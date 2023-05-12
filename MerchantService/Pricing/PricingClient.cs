public class PricingClient : IPricingManager
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly string PRICE_SERVICE_URL = "https://localhost:5002";
    private HttpClient Client => httpClientFactory.CreateClient();

    public PricingClient(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<ProductPrice> GetPrice(int productId)
    {
        return await Client.Get<ProductPrice>($"{PRICE_SERVICE_URL}/{productId}/price");
    }

    public async Task SetPrice(int productId, int price)
    {
        await Client.Post<UpdatePriceRequest>($"{PRICE_SERVICE_URL}/{productId}/price",
                                              new UpdatePriceRequest(price));
    }
}