using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTracker.Application.Commands.StocksCommands;
using StockTracker.Domain.Repositories.Interfaces;
using StockTracker.Infrastructure.Data;
using StockTracker.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StockTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StockTrackerConnection")));

builder.Services.AddScoped<IStockRepository, StockRepository>();

builder.Services.AddMediatR(typeof(CreateStockCommand));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();