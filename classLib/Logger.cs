using System;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;

namespace classLib {
    public static class Logger {
        public static IWebHostBuilder EnableLogger (this IWebHostBuilder builder) {

            Log.Logger = new LoggerConfiguration ()
                .MinimumLevel.Debug ()
                .MinimumLevel.Override ("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext ()
                .WriteTo.Console ()
                .CreateLogger ();

            builder.UseSerilog ();

            return builder;
        }

    }
}