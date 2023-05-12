var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IStockManager, StockManager>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.AddExceptionHandler();
app.MapEndpoints();

app.Run();