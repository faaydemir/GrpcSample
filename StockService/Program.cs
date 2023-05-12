using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IStockManager, StockManager>();
builder.Services.AddCodeFirstGrpc();

var app = builder.Build();
app.MapGrpcService<StockServiceGrpc>();
app.Run();