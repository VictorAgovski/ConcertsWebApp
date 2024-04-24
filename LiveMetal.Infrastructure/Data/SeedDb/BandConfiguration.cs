using LiveMetal.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Infrastructure.Data.SeedDb
{
    internal class BandConfiguration : IEntityTypeConfiguration<Band>
    {
        public void Configure(EntityTypeBuilder<Band> builder)
        {
            builder
                .HasMany(b => b.BandMembers)
                .WithOne(m => m.Band)
                .HasForeignKey(b => b.BandId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(b => b.Concerts)
                .WithOne(c => c.Band)
                .HasForeignKey(b => b.BandId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Band[] { data.HeavyMetalBand, data.ThrashMetalBand, data.DeathMetalBand, data.BlackMetalBand });
        }
    }
}
