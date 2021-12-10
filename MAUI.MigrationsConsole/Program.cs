using MAUI.CleanArchitecture.Application.Settings;
using MAUI.CleanArchitecture.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//var appSettingsJson = File.ReadAllText("../MAUI.CleanArchitecture/Configuration/appsettings.debug.json");
//var appSettings = JsonSerializer.Deserialize<AppSettings>(appSettingsJson);

var appSettings = new AppSettings() { ConnectionStrings = new ConnectionStrings { DefaultConnection = "test.db"} };
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddInfrastructure())
    .Build();

await host.RunAsync();

