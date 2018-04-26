using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace test {
    public class Program {
        public static void Main (string[] args) {
            try {
                //  Log.Information ("Webhost started");
                BuildWebHost (args).Run ();
              //  return 0;
            } catch (Exception ex) {
                throw ex;
                 // Log.Fatal (ex, "Host terminated unexpectedly");
              //  return 1;
            } finally {
                //   Log.CloseAndFlush ();
            }
        }

        public static IWebHost BuildWebHost (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> () 
            .Build ();
    }
}