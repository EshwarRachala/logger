using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using classLib;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace test {
    public class Program {
        public static void Main (string[] args) {
            try {
                BuildWebHost (args).Run ();
            } catch (Exception ex) {
                Log.Error (ex, "error");
            } finally {
                Log.CloseAndFlush ();
            }
        }

        public static IWebHost BuildWebHost (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ()
            .LogToConsole ()
            .LogToFile ("logs/log.txt")
            .LogToSqlServer ()
            .SendEmail ()
            .EnableLogger ()
            .Build ();
    }
}