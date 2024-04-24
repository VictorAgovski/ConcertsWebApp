using LiveMetal.Infrastructure.Data.Models;
using LiveMetal.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiveMetal.Infrastructure.Data
{
    public class LiveMetalDbContext : IdentityDbContext<ApplicationUser>
    {
        public LiveMetalDbContext(DbContextOptions<LiveMetalDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserClaimsConfiguration());
            builder.ApplyConfiguration(new BandConfiguration());
            builder.ApplyConfiguration(new ConcertConfiguration());
            builder.ApplyConfiguration(new MemberConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new VenueConfiguration());
            builder.ApplyConfiguration(new NewsConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Band> Bands { get; set; } = null!;

        public DbSet<Concert> Concerts { get; set; } = null!;

        public DbSet<Member> Members { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;

        public DbSet<Venue> Venues { get; set; } = null!;

        public DbSet<News> News { get; set; } = null!;
    }
}
