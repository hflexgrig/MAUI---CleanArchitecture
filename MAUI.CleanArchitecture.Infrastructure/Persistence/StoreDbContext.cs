using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Domain.Entities;
using MAUI.CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Infrastructure.Persistence
{
    public class StoreDbContext : IdentityDbContext<ApplicationUser>, IStoreDbContext
    {
        private readonly IConfiguration _configuration;

        public StoreDbContext(DbContextOptions<StoreDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<StoreItem> StoreItems { get; set; }
        public DbSet<CardItem> CardItems { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

        public Task MigrateAsync(CancellationToken token)
        {
            return Database.MigrateAsync(token);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Path.Combine(Environment.GetFolderPath(folder), "Test");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var dbPath = string.Format(_configuration.GetConnectionString("DefaultConnection"), path);
            options.UseSqlite(dbPath);
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
