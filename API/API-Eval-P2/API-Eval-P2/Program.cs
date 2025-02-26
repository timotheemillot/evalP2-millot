using API_Eval_P2;
using API_Eval_P2.Models;
using API_Eval_P2.Repositories;
using API_Eval_P2.Services.Applications;
using API_Eval_P2.Services.Passwords;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicationsService, ApplicationsService>();
builder.Services.AddScoped<IPasswordsService, PasswordsService>();

builder.Services.AddScoped<IRepository<Application>, ApplicationRepository>();
builder.Services.AddScoped<IRepository<Password>, PasswordRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
