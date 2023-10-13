using CardapioOnlineAPI.Db;
using CardapioOnlineAPI.Repositorys.Impl;
using CardapioOnlineAPI.Services;
using CardapioOnlineAPI.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddTransient<IMenuRepository, MenuEFRepositoryImpl>();


string? connectionString = builder.Configuration.GetConnectionString("DEFAULT");

builder.Services.AddDbContext<AppDbContext>(Options =>
    Options.UseNpgsql(connectionString), ServiceLifetime.Transient, ServiceLifetime.Transient
);

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
