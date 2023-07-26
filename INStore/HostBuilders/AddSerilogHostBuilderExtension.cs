using INStore.State.Registers;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace INStore.HostBuilders
{
    public static class AddSerilogHostBuilderExtension
    {
        public static IHostBuilder AddSerilog(this IHostBuilder host)
        {
            host.UseSerilog((host, loggerConfiguration) =>
            {
                loggerConfiguration.WriteTo.File(LoggingPathAssembler(), rollingInterval: RollingInterval.Day)
                    .WriteTo.Debug()
                    .MinimumLevel.Information();
            });

            return host;
        }
        private static string LoggingPathAssembler()
        {
            IRegister register = new Register();
            return register.GetLoggingLocation();

        }

    }
}
