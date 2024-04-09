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

        public Band HeavyMetalBand { get; set; }

        public Band ThrashMetalBand { get; set; }

        public Band DeathMetalBand { get; set; }

        public Band BlackMetalBand { get; set; }

        public Concert FirstConcert { get; set; }

        public Concert SecondConcert { get; set; }

        public Member FirstMember { get; set; }

        public Member SecondMember { get; set; }

        public Member ThirdMember { get; set; }

        public Member FourthMember { get; set; }

        public Member FifthMember { get; set; }

        public Member SixthMember { get; set; }

        public Member SeventhMember { get; set; }

        public Member EighthMember { get; set; }

        public Member NinthMember { get; set; }

        public Member TenthMember { get; set; }

        public Review FirstReview { get; set; }

        public Review SecondReview { get; set; }

        public Review ThirdReview { get; set; }

        public Venue FirstVenue { get; set; }

        public Venue SecondVenue { get; set; }

        public Venue ThirdVenue { get; set; }

        public UserFavourite FirstFavourite { get; set; }

        public UserFavourite SecondFavourite { get; set; }

        public UserFavourite ThirdFavourite { get; set; }

        public SeedData()
        {
            SeedUsers();
            //SeedBands();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            GuestUser = new ApplicationUser
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Guest",
                LastName = "Guestov",
                ProfilePictureUrl = "https://ohsobserver.com/wp-content/uploads/2022/12/Guest-user.png"
            };

            GuestUserClaim = new IdentityUserClaim<string>
            {
                Id = 1,
                UserId = GuestUser.Id,
                ClaimType = "user:fullname",
                ClaimValue = $"{GuestUser.FirstName} {GuestUser.LastName}"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest123");

            AdminUser = new ApplicationUser
            {
                Id = "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com",
                FirstName = "Admin",
                LastName = "Adminov",
                ProfilePictureUrl = "https://www.wpeka.com/rgh/wp-content/uploads/2014/03/Changing-the-default-admin-user-in-WordPress1-e1462965535256.jpg"
            };

            AdminUserClaim = new IdentityUserClaim<string>
            {
                Id = 2,
                UserId = AdminUser.Id,
                ClaimType = "user:fullname",
                ClaimValue = $"{AdminUser.FirstName} {AdminUser.LastName}"
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin123");

            RegisteredUser = new ApplicationUser
            {
                Id = "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1",
                UserName = "registered@mail.com",
                NormalizedUserName = "registered@mail.com",
                Email = "registered@mail.com",
                NormalizedEmail = "registered@mail.com",
                FirstName = "Registered",
                LastName = "Registeredov",
                ProfilePictureUrl = "https://www.pngkey.com/png/detail/73-730394_admin-approved-user-registration-user-registration-icon-png.png"
            };

            RegisteredUserClaim = new IdentityUserClaim<string>
            {
                Id = 3,
                UserId = RegisteredUser.Id,
                ClaimType = "user:fullname",
                ClaimValue = $"{RegisteredUser.FirstName} {RegisteredUser.LastName}"
            };

            RegisteredUser.PasswordHash = hasher.HashPassword(RegisteredUser, "registered123");
        }

        //private void SeedBands()
        //{
        //    HeavyMetalBand = new Band
        //    {
        //        BandId = 1,
        //        Name = "Heavy Metal Band",
        //        Genre = "Heavy Metal",
        //        Country = "USA",
        //        YearFormed = 1980
        //    };
        //}
    }
}
