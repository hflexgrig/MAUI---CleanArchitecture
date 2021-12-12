using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Infrastructure.BackgroundServices
{
    public class DbBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DbBackgroundService(IServiceProvider serviceProvider, SignInManager<ApplicationUser> signInManager)
        {
            _serviceProvider = serviceProvider;
            _signInManager = signInManager;

            // ExecuteAsync(default);
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IStoreDbContext>();
                _signInManager.Context = new DefaultHttpContext { RequestServices = scope.ServiceProvider };

                await dbContext.MigrateAsync(stoppingToken);


            }

        }
    }
}
