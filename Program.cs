

using AutoMapper;
using IFMS_Master_Backend.BAL.IServices;
using IFMS_Master_Backend.BAL.Services;
using IFMS_Master_Backend.DAL.Entities;
using IFMS_Master_Backend.DAL.IRepositories;
using IFMS_Master_Backend.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddTransient<IDetailHeadRepo, DetailHeadRepo>();
builder.Services.AddTransient<ISubDetailHeadRepo, SubDetailHeadRepo>();
builder.Services.AddTransient<IDdoRepo, DdoRepo>();
builder.Services.AddTransient<ITreasuryRepo, TreasuryRepo>();


//Services
builder.Services.AddTransient<IMajorHeadService, MajorHeadService>();
builder.Services.AddTransient<ISubMajorHeadService, SubMajorHeadService>();
builder.Services.AddTransient<IMinorHeadService, MinorHeadService>();
builder.Services.AddTransient<IDetailHeadService, DetailHeadService>();
builder.Services.AddTransient<ISubDetailHeadService, SubDetailHeadService>();
builder.Services.AddTransient<IDdoService, DdoService>();
builder.Services.AddTransient<ITreasuryService, TreasuryService>();


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

app.UseCors(option => option.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
