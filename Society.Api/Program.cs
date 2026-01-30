using Microsoft.EntityFrameworkCore;
using Society.Application.Interfaces.Repositories;
using Society.Application.Interfaces.Services;
using Society.Application.Services;
using Society.Infrastructure.Data;
using Society.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Society.Application.DTOs.Auth;
using Society.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SocietyDbContext>
(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddControllers().AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssemblyContaining<RegisterRequestDtoValidator>();
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
