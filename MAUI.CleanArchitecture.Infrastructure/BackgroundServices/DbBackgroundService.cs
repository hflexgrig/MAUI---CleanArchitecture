using MAUI.CleanArchitecture.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MAUI.CleanArchitecture.Infrastructure.BackgroundServices
{
    public class DbBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public DbBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IStoreDbContext>();

                await dbContext.MigrateAsync(stoppingToken);
            }

        }
    }
}
