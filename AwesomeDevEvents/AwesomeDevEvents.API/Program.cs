using AwesomeDevEvents.API.Mappers;
using AwesomeDevEvents.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DevEventsCs");

//builder.Services.AddDbContext<DevEventDbContext>(o => o.UseInMemoryDatabase("DevEventsDb")); Para Utilizar o banco de dados em memoria
builder.Services.AddDbContext<DevEventDbContext>(o => o.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(typeof(DevEventProfile).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AwesomeDevEvents.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Carlos Felipe L. da Silva",
            Email = "felipeleopoldino01@icloud.com",
            Url = new Uri("https://www.linkedin.com/in/carlos-leopoldino/")
        }
    });
    var xmlFile = "AwesomeDevEvents.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
