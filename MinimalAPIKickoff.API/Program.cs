using Microsoft.EntityFrameworkCore;
using MinimalAPIKickoff.API.Endpoints;
using MinimalAPIKickoff.API.Middlewares;
using MinimalAPIKickoff.Application.Services;
using MinimalAPIKickoff.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);


if (builder.Environment.IsEnvironment("Test"))
{
    builder.Services.AddDbContext<MinimalAPIKickoffContext>(options =>
        options.UseInMemoryDatabase("TestDb"));
}
else
{
    builder.Services.AddDbContext<MinimalAPIKickoffContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}




builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<UserExceptionHandler>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.MapUserEndpoints();

app.Run();

public partial class Program { }