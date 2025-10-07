using BlogApiProject.Application.Employees;
using BlogApiProject.Application.Roles;
using BlogApiProject.Data;
using BlogApiProject.Data.Employees;
using BlogApiProject.Data.Roles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Get connection string
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(option =>
option.UseSqlServer(connection));

builder.Services.AddScoped<IEmployeeApplication, EmployeeApplication>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRoleApplication, RoleApplication>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
