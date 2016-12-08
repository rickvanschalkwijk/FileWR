using System;
using System.Threading.Tasks;
using FileWR.Business;
using FileWR.DI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;

namespace FileWR
{
    public static class Program
    {
        private static readonly IServiceCollection Services = new ServiceCollection();

        public static void Main(string[] args)
        {
            var container = ConfigureServices(Services);

            // set up all the console properties
            SetUpConsole();

            // run the main task
            Task.Run(async () =>
            {
                await new FileWR(container.GetInstance<IFileService>(), container.GetInstance<IDirectoryService>()).Run();
            }).Wait();

            Console.Write("\nPress any key to exit... ");
            Console.ReadKey();
        }

        private static Container ConfigureServices(IServiceCollection services)
        {
            ILoggerFactory loggerFactory = new LoggerFactory()
                .AddConsole()
                .AddDebug();

            services.AddSingleton(loggerFactory);
            services.AddLogging();

            // get the structuremap container
            var container = StructureMapConfig.Init(services);

            return container;
        }

        private static void SetUpConsole()
        {
            Console.Title = "FileWR";
            Console.WindowHeight = 75;
            Console.WindowWidth = 75;
        }
    }
}
