using MAUI.CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Common.Interfaces
{
    public interface IStoreDbContext
    {
        DbSet<StoreItem> StoreItems { get; set; }
        DbSet<CardItem> CardItems { get; set; }

        Task MigrateAsync(CancellationToken token);
    }
}
