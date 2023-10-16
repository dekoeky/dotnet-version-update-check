using Checker.Services;
using Microsoft.AspNetCore.Builder;
using Serilog;
using Wvk.Dotnet.UpdateCheck;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger());

builder.Services.AddHttpClient<IDotnetVersionRetrieval, DotnetVersionRetrievalClient>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();

host.Run();
