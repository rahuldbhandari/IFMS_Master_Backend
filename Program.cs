using AutoMapper;
using IFMS_Master_Backend.BAL.Interface;
using IFMS_Master_Backend.BAL.Services;
using IFMS_Master_Backend.DAL;
using IFMS_Master_Backend.DAL.Interfaces;
using IFMS_Master_Backend.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<IfmsDBContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(5), null)
), ServiceLifetime.Transient);

// Add services to the container.
// Add AutoMapper 
builder.Services.AddAutoMapper(typeof(Program));
//Repositories
builder.Services.AddTransient<ITreasuryRepo, TreasuryRepo>();

builder.Services.AddTransient<IDdoRepo, DdoRepo>();
//Services
builder.Services.AddTransient<ITreasuryService, TreasuryService>();
//Services
builder.Services.AddTransient<IDdoService, DdoService>();

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
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
