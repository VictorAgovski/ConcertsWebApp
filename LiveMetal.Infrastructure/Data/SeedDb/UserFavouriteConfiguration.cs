using LiveMetal.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Infrastructure.Data.SeedDb
{
    internal class UserFavouriteConfiguration : IEntityTypeConfiguration<UserFavourite>
    {
        public void Configure(EntityTypeBuilder<UserFavourite> builder)
        {
            builder
                .HasKey(uf => new { uf.UserId, uf.BandId });

            builder
                .HasOne(uf => uf.User)
                .WithMany(u => u.UserFavourites)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new UserFavourite[] { data.FirstFavourite, data.SecondFavourite, data.ThirdFavourite });
        }
    }
}
