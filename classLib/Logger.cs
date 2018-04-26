using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace classLib {

    public static class Logger {

        public static LoggerConfiguration logger;
        public static IWebHostBuilder EnableLogger (this IWebHostBuilder builder,
            IConfiguration configuration = null, IHostingEnvironment environment = null) {

            Log.Logger = logger.CreateLogger ();

            builder.UseSerilog ();

            return builder;
        }

        public static IWebHostBuilder AddConsole (this IWebHostBuilder builder) {

            logger = new LoggerConfiguration ()
                .MinimumLevel.Debug ()
                .MinimumLevel.Override ("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext ();

            logger.WriteTo.Console (theme: AnsiConsoleTheme.Code,
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}");

            return builder;
        }

    }
}