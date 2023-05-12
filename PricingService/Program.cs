var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IErrorResponseBuilder, ErrorResponseBuilder>();
builder.Services.AddSingleton<IPricingManager, PricingManager>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.AddExceptionHandler();
app.MapEndpoints();

app.Run();