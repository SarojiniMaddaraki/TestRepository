using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskApp.DAL;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TaskApplicationContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("TaskConnectionString")));

builder.Services.AddScoped<TaskApplicationContext>();
builder.Services.AddScoped<TaskApp.Service.TaskService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
