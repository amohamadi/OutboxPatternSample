using Data;
using Microsoft.EntityFrameworkCore;
using OrderApi.Config;
using RabbitMQ.Client;
using Service.Contract;
using Service.Implement;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJob();
builder.Services.AddRabbitMq(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Cnn")));

builder.Services.AddScoped<IEventBusService, EventBusService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IEventService, EventService>();

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