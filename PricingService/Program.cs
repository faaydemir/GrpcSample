var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddSingleton<IErrorResponseBuilder, ErrorResponseBuilder>();
builder.Services.AddSingleton<IPricingManager, PricingManager>();
builder.Services.AddGrpc();

var app = builder.Build();
app.MapGrpcService<PricingServiceGrpc>();
//app.AddExceptionHandler();

app.Run();