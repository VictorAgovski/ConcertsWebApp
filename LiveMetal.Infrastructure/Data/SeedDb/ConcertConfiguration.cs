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
    internal class ConcertConfiguration : IEntityTypeConfiguration<Concert>
    {
        public void Configure(EntityTypeBuilder<Concert> builder)
        {
            builder
                .HasOne(c => c.Creator)
                .WithMany(u => u.Concerts)
                .HasForeignKey(c => c.CreatorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(c => c.Band)
                .WithMany(b => b.Concerts)
                .HasForeignKey(c => c.BandId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Venue)
                .WithMany(b => b.Concerts)
                .HasForeignKey(c => c.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Concert[] { data.FirstConcert, data.SecondConcert, data.ThirdConcert });
        }
    }
}
