using Microsoft.EntityFrameworkCore;
using StudentApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura il DbContext con SQLite
builder.Services.AddDbContext<StudentContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Aggiunge i servizi necessari
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Abilita Swagger solo in sviluppo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
