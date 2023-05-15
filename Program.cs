using MusicShopc.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISaleService, SaleService>(); 
//ensures that
//a new instance of
//the service is created for each client request

builder.Services.AddSingleton<IProductService, ProductService>();
//ensures that
//a single instance of the service
//is shared across all clients and requests

builder.Services.AddScoped<IPurchaseService, PurchaseService>();
//purchases service may involve stateful
//operations and have different instances
//for different clients or requests

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
