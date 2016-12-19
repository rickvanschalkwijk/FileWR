using FileWR.Business;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace FileWR.DI
{
    public static class StructureMapConfig
    {
        public static Container Init(IServiceCollection serviceCollection)
        {
            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Program));
                    _.AssemblyContainingType(typeof(FileService));
                    _.WithDefaultConventions();
                });
            });

            container.Populate(serviceCollection);

            return container;
        }
    }
}
