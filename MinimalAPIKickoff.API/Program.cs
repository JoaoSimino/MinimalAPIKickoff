using Microsoft.EntityFrameworkCore;
using MinimalAPIKickoff.API.Endpoints;
using MinimalAPIKickoff.Application.Services;
using MinimalAPIKickoff.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MinimalAPIKickoffContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapUserEndpoints();

app.Run();
