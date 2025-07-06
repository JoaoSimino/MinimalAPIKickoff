using Microsoft.EntityFrameworkCore;
using MinimalAPIKickoff.API.Endpoints;
using MinimalAPIKickoff.API.Middlewares;
using MinimalAPIKickoff.Application.Services;
using MinimalAPIKickoff.Infrastructure.Data;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

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


var outputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}";
var sinkOptions = new MSSqlServerSinkOptions
{
    TableName = "Logs",
    AutoCreateSqlTable = true,
};

//column configurations
var columnOptions = new ColumnOptions();
columnOptions.Store.Remove(StandardColumn.Properties);
columnOptions.Store.Add(StandardColumn.LogEvent);
columnOptions.TimeStamp.NonClusteredIndex = true;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .Enrich.WithEnvironmentName()
    .Enrich.WithMachineName()
    .Enrich.WithProcessId()
    .Enrich.WithThreadId()
    .WriteTo.Console(outputTemplate: outputTemplate)
    .WriteTo.MSSqlServer(
        connectionString: builder.Configuration.GetConnectionString("DefaultConnection")!,
        sinkOptions: sinkOptions,
        columnOptions: columnOptions,
        restrictedToMinimumLevel: LogEventLevel.Information
    )
    .WriteTo.File(
    path: "Logs/app.log",
    outputTemplate: outputTemplate,
    rollingInterval: RollingInterval.Day,
    flushToDiskInterval: TimeSpan.FromSeconds(1),
    shared: true
    )
    .CreateLogger();

builder.Host.UseSerilog();


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