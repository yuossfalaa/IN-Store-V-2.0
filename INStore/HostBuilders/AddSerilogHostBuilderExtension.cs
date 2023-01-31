using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStore.HostBuilders
{
    public static class AddSerilogHostBuilderExtension
    {
        public static IHostBuilder AddSerilog(this IHostBuilder host)
        {
            host.UseSerilog((host, loggerConfiguration) =>
            {
                loggerConfiguration.WriteTo.File(LoggingPathAssembler().Result, rollingInterval: RollingInterval.Day)
                    .WriteTo.Debug()
                    .MinimumLevel.Information();
            });

            return host;
        }
        private static async Task<string> LoggingPathAssembler()
        {
            string LoggingPath = "";
            try
            {
                LoggingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //AppData\Roaming
                LoggingPath = LoggingPath + @"\IN Store\Logs";
                System.IO.Directory.CreateDirectory(LoggingPath);
                LoggingPath += @"\INStore - .txt";

            }
            catch (Exception ConnectionStringAssemblerFailed)
            {

            }
            return LoggingPath;


        }

    }
}
