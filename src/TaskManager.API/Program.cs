using TaskManager.Application.Implementations;
using TaskManager.Application.Interfaces;
using TaskManager.Infrastructure.Context;
using TaskManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://+:5001");

// Registrar o AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<SqlDbContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")));

// Add services to the container.
// Register repositories and services
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectUserRepository, ProjectUserRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskHistoryRepository, TaskHistoryRepository>();
builder.Services.AddScoped<ITaskUserRepository, TaskUserRepository>();
builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
