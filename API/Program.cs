using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using API.Extension;
using AspNetCoreRateLimit;
using AutoMapper;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureApiVersioning();
builder.Services.ConfigureRatelimiting();
builder.Services.ConfigureCors();
builder.Services.AddAplicacionServices();
builder.Services.ConfigureJson();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddDbContext<APIContext>(options => {
    string con = builder.Configuration.GetConnectionString("DefaultConecction");
    options.UseMySql(con, ServerVersion.AutoDetect(con));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.UseApiVersioning();
app.UseIpRateLimiting();
app.MapControllers();

app.Run();
