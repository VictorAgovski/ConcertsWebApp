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

            var data = new SeedData();

            builder.HasData(new Concert[] { data.FirstConcert, data.SecondConcert, data.ThirdConcert });
        }
    }
}
