using System.Text;
using ECommerce_API.Context;
using ECommerce_API.Interfaces;
using ECommerce_API.Repositories;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EcommerceContext>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IItemProdutoRepository, ItemPedidoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "ecommerce",
                ValidAudience = "ecommerce",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-secreta-senai"))
            };   
        });

builder.Services.AddAuthentication();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Run();