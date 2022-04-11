using Microsoft.EntityFrameworkCore;
using PaymentGateway.Infrastructure.Database;
using PaymentGateway.Presentation.API.DI;
using PaymentGateway.Application.Services.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("PaymentGateway"));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(x=> x.AddMaps(typeof(MapperProfile).Assembly));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAPIGatewayDependencies();
builder.Services.AddSwaggerGen();

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
public partial class Program { }