using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Newtonsoft.Json;
using dfEvents.DataAccess.Repository;
using dfEvents.Mapping;

namespace dfEvents
{
    internal partial class Startup
    {
        //private const string ServicesAPISectionName = "ServicesAPI";
        /// <summary>
        /// Registered any misc services.
        /// This method gets called by the startup class automatically.
        /// </summary>
        /// <param name="services"></param>
        public static void AddDependencies(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters()
                .AddJsonOptions(opt =>
                    opt.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter()));

            services.AddScoped<IEventRepository, EventRepository>();

            var mapper = new MapperConfiguration(c => c.AddProfile<MappingProfile>()).CreateMapper();
            services.AddSingleton<IMapper>(mapper);


        }
    }
}
