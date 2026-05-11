using Todo.Application.Interfaces;
using Todo.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();   
builder.Services.AddSingleton<ITodoService, TodoService>();

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();    
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.Run();