using dfEvents;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace dfEvents
{
    internal partial class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            AddDatabase(builder.Services);
            AddDependencies(builder.Services);
        }
    }
}
