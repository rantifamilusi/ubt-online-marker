using Microsoft.EntityFrameworkCore;
using OnlineMarker.Api.Repository.Implementation;
using OnlineMarker.Api.Repository.Interfaces;
using OnlineMarker.Domain.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<NGOnlineMarkerContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineMarkerConnection"),
        b => b.MigrationsAssembly(typeof(NGOnlineMarkerContext).Assembly.FullName)));

builder.Services.AddScoped<IOnlineMarkerService, OnlineMarkerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();

app.Run();