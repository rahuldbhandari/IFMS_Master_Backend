using AutoMapper;
using IFMS_Master_Backend.DAL.Interfaces;
using IFMS_Master_Backend.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using IFMS_Master_Backend.BAL.Interfaces;
using IFMS_Master_Backend.BAL.Servises;
using IFMS_Master_Backend.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ifmsContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(5), null)
), ServiceLifetime.Transient);

// Add AutoMapper 
builder.Services.AddAutoMapper(typeof(Program));

// Repositories

builder.Services.AddTransient<IMajorHeadRepo, MajorHeadRepo>();
builder.Services.AddTransient<ISubMajorHeadRepo, SubMajorHeadRepo>();
builder.Services.AddTransient<IMinorHeadRepo, MinorHeadRepo>();

//Services
builder.Services.AddTransient<IMajorHeadService, MajorHeadService>();
builder.Services.AddTransient<ISubMajorHeadService, SubMajorHeadService>();
builder.Services.AddTransient<IMinorHeadService, MinorHeadService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
