using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleTravelManagement.Application.Services;
using SimpleTravelManagement.Infrastructure.EF;
using SimpleTravelManagement.Infrastructure.Services;
using SimpleTravelManagement.Shared.Abstractions.Commands;
using SimpleTravelManagement.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTravelManagement.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSQLDB(configuration);
            services.AddQueries();
            services.AddSingleton<IWeatherService, DumbWeatherService>();


            return services;
        }
    }
}
