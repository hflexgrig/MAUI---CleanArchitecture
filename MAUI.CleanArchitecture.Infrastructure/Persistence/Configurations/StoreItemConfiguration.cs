using MAUI.CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class StoreItemConfiguration : IEntityTypeConfiguration<StoreItem>
    {
        public void Configure(EntityTypeBuilder<StoreItem> builder)
        {
            builder.Property(t => t.Id).IsUnicode(true).ValueGeneratedNever();
            builder.HasKey(t => t.Id);

            builder.Property<long>("CardRef");
            builder.HasKey("CardRef");

            builder.Property(t => t.Title).HasMaxLength(200);
            builder.Property(t => t.Price).HasPrecision(18, 2);

            builder.HasOne(t => t.Rating).WithOne().HasForeignKey<Rating>("StoreRef");
        }
    }
}
