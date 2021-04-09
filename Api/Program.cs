using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Timers;

namespace Api
{
    public class Program
    {
        public static Timer timer = new Timer();

        public static void Main(string[] args)
        {
            timer.AutoReset = false;
            timer.Interval = 2500;
            timer.Elapsed += new ElapsedEventHandler(ExecutarTarefa);
            timer.Enabled = true;

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        static void ExecutarTarefa(object sender, ElapsedEventArgs e)
        {
            timer.Enabled = false;

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Users\Juninho\Desktop\Programação\Facebook\Facebook-API\script.sh")
            {
                UseShellExecute = true
            };
            p.Start();

            timer.Enabled = true;
        }
    }
}
