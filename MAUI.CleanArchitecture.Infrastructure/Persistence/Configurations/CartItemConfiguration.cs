using MAUI.CleanArchitecture.Domain.Entities;
using MAUI.CleanArchitecture.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CardItem>
    {
        public void Configure(EntityTypeBuilder<CardItem> builder)
        {
            builder.Property<long>("StoreRef");
            builder.HasKey("StoreRef");

            builder.HasOne(t => t.StoreItem).WithOne().HasForeignKey<StoreItem>("CardRef");

            //var identityUser = "IdentityUser";
            //builder.Property<ApplicationUser>(identityUser);
            //builder.HasOne(identityUser).WithMany();
        }
    }
}
