using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TCP_Chat.Date;
using static TCP_Chat.CreateRole;

namespace TCP_Chat {
    public class Program {
        public static void Main (string[] args) {
            // CreateWebHostBuilder (args).Build ().Run ();

            var host = BuildWebHost (args);
            using (var scope = host.Services.CreateScope ()) {
                var services = scope.ServiceProvider;
                try {
                    var context = services.GetService<AppDbContext> ();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>> ();

                    IdentityDataInit.SeedData (roleManager);
                } catch {
                    //Обработка ошибки
                }
            }
            host.Run ();
        }

        public static IWebHost BuildWebHost (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseStartup<Startup> ()
            .Build ();
    }
}