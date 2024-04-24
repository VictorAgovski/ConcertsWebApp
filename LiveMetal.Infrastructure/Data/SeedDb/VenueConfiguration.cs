using LiveMetal.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Infrastructure.Data.SeedDb
{
    internal class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder
                .HasMany(v => v.Concerts)  
                .WithOne(c => c.Venue) 
                .HasForeignKey(c => c.VenueId) 
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(v => v.Concerts)
                .WithOne(c => c.Venue)
                .HasForeignKey(c => c.VenueId)
                .OnDelete(DeleteBehavior.SetNull);

            var data = new SeedData();

            builder.HasData(new Venue[] { data.FirstVenue, data.SecondVenue, data.ThirdVenue });
        }
    }
}
