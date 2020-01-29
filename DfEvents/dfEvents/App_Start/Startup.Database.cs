using System;
using Computershare.Common.NPoco;
using Microsoft.Extensions.DependencyInjection;

namespace dfEvents
{
    internal partial class Startup
    {

        /// <summary>
        /// Add Database.
        /// This method gets called by the startup class automatically.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDatabase(IServiceCollection services)
        {
            // Database
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

            services.AddDatabaseConnection(connectionString);
        }
    }
}
