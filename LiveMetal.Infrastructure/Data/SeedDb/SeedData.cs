using LiveMetal.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public ApplicationUser GuestUser { get; set; }

        public ApplicationUser AdminUser { get; set; }

        public ApplicationUser RegisteredUser { get; set; }

        public IdentityUserClaim<string> GuestUserClaim { get; set; }

        public IdentityUserClaim<string> AdminUserClaim { get; set; }

        public IdentityUserClaim<string> RegisteredUserClaim { get; set; }


    }
}
