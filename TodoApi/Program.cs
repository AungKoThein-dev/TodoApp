using Microsoft.EntityFrameworkCore;
using Todo.Application.Interfaces;
using Todo.Infrastructure.Data;
using Todo.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

//app.MapGet("/hello", () => "Hello Docker!");
//app.Urls.Add("http://0.0.0.0:8080");
app.Run();