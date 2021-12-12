using MAUI.CleanArchitecture.Application.Settings;
using MAUI.CleanArchitecture.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Text.Json;
// See https://aka.ms/new-console-template for more information

#if DEBUG
    var appSettingsStream = Assembly.LoadFrom("../MAUI.CleanArchitecture/bin/Debug/net6.0-windows10.0.19041/win-x64/AppX/MAUI.CleanArchitecture.dll").GetManifestResourceStream("MAUI.CleanArchitecture.Configuration.appsettings.debug.json");
#else
    var appSettingsStream = Assembly.LoadFrom("../MAUI.CleanArchitecture/bin/Debug/net6.0-windows10.0.19041/win-x64/AppX/MAUI.CleanArchitecture.dll").GetManifestResourceStream("MAUI.CleanArchitecture.Configuration.appsettings.debug.json");
#endif

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((prop, config) =>
                config.AddJsonStream(appSettingsStream)
            )
    .ConfigureServices((_, services) =>
        services.AddInfrastructure())
    .Build();

await host.RunAsync();

