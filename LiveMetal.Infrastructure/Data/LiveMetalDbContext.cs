using LiveMetal.Infrastructure.Data.Models;
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
            builder.Entity<UserFavourite>()
                .HasKey(uf => new { uf.UserId, uf.BandId });

            builder.Entity<UserFavourite>()
                .HasOne(sp => sp.User)
                .WithMany(s => s.UserFavourites)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Review>()
                .HasOne(r => r.Concert)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.ConcertId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public DbSet<Band> Bands { get; set; } = null!;

        public DbSet<Concert> Concerts { get; set; } = null!;

        public DbSet<Member> Members { get; set; } = null!;

        public DbSet<Review> Reviews { get; set; } = null!;

        public DbSet<UserFavourite> UsersFavourites { get; set; } = null!;

        public DbSet<Venue> Venues { get; set; } = null!;
    }
}
