using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Assistant
{
    public class Program
    {
		public static IConfigurationRoot Configuration { get; set; }

		public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
			
		}

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
	}
}
