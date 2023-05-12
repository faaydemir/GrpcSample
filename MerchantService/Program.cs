var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IErrorResponseBuilder, ErrorResponseBuilder>();
builder.Services.AddSingleton<IMerchantManager, MerchantManager>();
builder.Services.AddSingleton<IPricingManager, PricingManager>();
builder.Services.AddSingleton<IStockManager, StockManager>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.AddExceptionHandler();
app.MapEndpoints();

app.Run();
