using LiveMetal.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Infrastructure.Data.SeedDb
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            var data = new SeedData();

            builder.HasData(new News[] { data.FirstNews, data.SecondNews, data.ThirdNews });
        }
    }
}
