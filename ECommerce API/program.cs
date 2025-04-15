using ECommerce_API.Context;
using ECommerce_API.Interfaces;
using ECommerce_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<EcommerceContext, EcommerceContext>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IItemProdutoRepository, ItemPedidoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();