using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using OnlineMarker.Api.Repository.Implementation;
using OnlineMarker.Api.Repository.Interfaces;
using OnlineMarker.Api.Settings;
using OnlineMarker.Api.Validations;
using OnlineMarker.Domain.Models;
using OnlineMarker.Shared.Request;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//options =>
//{
//    options.Filters.Add(new ValidationFilter());
//}

builder.Services.AddControllers( )
    .AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<NGOnlineMarkerContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineMarkerConnection"),
        b => b.MigrationsAssembly(typeof(NGOnlineMarkerContext).Assembly.FullName)));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Settings"));
builder.Services.AddScoped<IOnlineMarkerService, OnlineMarkerService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddTransient<IValidator<GetCandidateScriptsRequest>, GetCandidateScriptRequestValidator>();
builder.Services.AddTransient<IValidator<SaveMarkedScriptsRequest>, SaveMarkedScriptsRequestValidator>();
builder.Services.AddTransient<IValidator<SubmitMarkedScriptRequest>, SubmitMarkedScriptRequestValidator>();
builder.Services.AddTransient<IValidator<ResetScriptRequest>, ResetScriptRequestValidator>();
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