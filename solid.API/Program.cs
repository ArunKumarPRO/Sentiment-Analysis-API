using Microsoft.EntityFrameworkCore;
using solid.Repositories;
using solid.Repositories.Implementations;
using solid.Repositories.Interfaces;
using solid.Services;
//using solid.Services.Implementations;
using solid.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapping));
builder.Services.AddDbContext<AppDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("SentimentAnalysis"), builder => builder.MigrationsAssembly("solid.Repositories")));
builder.Services.AddTransient<ISentimentService, SentimentService>();
builder.Services.AddTransient<ISentimentRepository, SentimentRepository>();
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
