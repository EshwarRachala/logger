using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace classLib {
    
    public static class Logger {
        public static IWebHostBuilder EnableLogger (this IWebHostBuilder builder,
            IConfiguration configuration = null, IHostingEnvironment environment = null) {

            Log.Logger = new LoggerConfiguration ()
                .MinimumLevel.Debug ()
                .MinimumLevel.Override ("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext ()
                .WriteTo.Console (theme: AnsiConsoleTheme.Code,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger ();

            builder.UseSerilog ();

            return builder;
        }
 
    }
}