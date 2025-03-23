using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleTravelManagement.Application.Services;
using SimpleTravelManagement.Domain.Repositories;
using SimpleTravelManagement.Infrastructure.EF.Context;
using SimpleTravelManagement.Infrastructure.EF.Options;
using SimpleTravelManagement.Infrastructure.EF.Repositories;
using SimpleTravelManagement.Infrastructure.EF.Services;
using SimpleTravelManagement.Shared.Options;

namespace SimpleTravelManagement.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITravelerCheckListRepository, TravelerCheckListRepository>();
            services.AddScoped<ITravelerCheckListReadService, TravelerCheckListReadService>();

            var options = configuration.GetOptions<DataBaseOptions>("DataBaseConnectionString");
            services.AddDbContext<ReadDbContext>(ctx =>
            ctx.UseSqlServer(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
