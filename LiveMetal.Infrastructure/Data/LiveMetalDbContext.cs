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
    }
}
