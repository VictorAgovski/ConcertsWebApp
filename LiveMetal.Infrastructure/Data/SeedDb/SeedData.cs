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
            SeedBands();
            SeedMembers();
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

        private void SeedBands()
        {
            HeavyMetalBand = new Band
            {
                BandId = 1,
                Name = "Iron Maiden",
                Genre = "Heavy Metal",
                FormationYear = new DateTime(1975, 12, 25),
                Biography = "Iron Maiden are an English heavy metal band formed in Leyton, East London, in 1975 by bassist and primary songwriter Steve Harris. The band's discography has grown to 40 albums, including 16 studio albums, 13 live albums, four EPs, and seven compilations.",
                BandImageUrl = "https://w0.peakpx.com/wallpaper/812/225/HD-wallpaper-iron-maiden-the-trooper-music-band-trooper-flag-metal-iron-maiden-logo-heavy-iron-eddie-sword-maiden.jpg",
            };

            ThrashMetalBand = new Band
            {
                BandId = 2,
                Name = "Metallica",
                Genre = "Thrash Metal",
                FormationYear = new DateTime(1981, 10, 28),
                Biography = "Metallica is an American heavy metal band. The band was formed in 1981 in Los Angeles by vocalist/guitarist James Hetfield and drummer Lars Ulrich, and has been based in San Francisco for most of its career.",
                BandImageUrl = "https://i.pinimg.com/originals/04/8a/f7/048af73296084481c48c99c5f70ab378.jpg"
            };

            DeathMetalBand = new Band
            {
                BandId = 3,
                Name = "Nile",
                Genre = "Death Metal",
                FormationYear = new DateTime(1993, 11, 1),
                Biography = "Nile is an American death metal band from Greenville, South Carolina, formed in 1993. The band is known for its technical and complex style of death metal.",
                BandImageUrl = "https://static.wikia.nocookie.net/logopedia/images/6/6f/Nileband_logo.jpg/revision/latest?cb=20160624042213"
            };

            BlackMetalBand = new Band
            {
                BandId = 4,
                Name = "Darkthrone",
                Genre = "Black Metal",
                FormationYear = new DateTime(1986, 6, 1),
                Biography = "Darkthrone is a Norwegian black metal band. It formed in 1986 as a death metal band under the name Black Death. In 1991, the band embraced a black metal style influenced by Bathory and Celtic Frost and became one of the leading bands in the Norwegian black metal scene.",
                BandImageUrl = "https://i.pinimg.com/originals/b6/30/32/b630323cff6fdfe395e5127fb73a45e3.jpg"
            };
        }

        private void SeedMembers()
        {
            FirstMember = new Member
            {
                MemberId = 1,
                FullName = "Steve Harris",
                Biography = "Stephen Percy Harris (born 12 March 1956) is an English musician who is the bassist, keyboardist, backing vocalist, primary songwriter and founder of heavy metal band Iron Maiden.",
                Role = "Bass Guitar",
                BandId = 1,
                DateOfBirth = new DateTime(1956, 3, 12),
                DateOfJoining = new DateTime(1975, 12, 25)
            };

            SecondMember = new Member
            {
                MemberId = 2,
                FullName = "Dave Murray",
                Biography = "David Michael Murray (born 23 December 1956) is an English guitarist and songwriter best known as one of the earliest members of the British heavy metal band Iron Maiden.",
                Role = "Lead Guitar",
                BandId = 1,
                DateOfBirth = new DateTime(1956, 12, 23),
                DateOfJoining = new DateTime(1976, 12, 25)
            };

            ThirdMember = new Member
            {
                MemberId = 3,
                FullName = "Lars Ulrich",
                Biography = "Lars Ulrich (born 26 December 1963) is a Danish musician best known as the drummer and co-founder of American heavy metal band Metallica.",
                Role = "Drums",
                BandId = 2,
                DateOfBirth = new DateTime(1963, 12, 26),
                DateOfJoining = new DateTime(1981, 10, 28)
            };

            FourthMember = new Member
            {
                MemberId = 4,
                FullName = "Karl Sanders",
                Biography = "Karl Sanders (born 5 June 1964) is an American musician, most widely known as the founding member of the American death metal band Nile.",
                Role = "Guitar",
                BandId = 3,
                DateOfBirth = new DateTime(1964, 6, 5),
                DateOfJoining = new DateTime(1993, 11, 1)
            };

            FifthMember = new Member
            {
                MemberId = 5,
                FullName = "Fenriz",
                Biography = "Gylve Fenris Nagell (born 28 November 1971), better known as Fenriz, is a Norwegian musician and politician who is best known as being one half of the metal duo Darkthrone.",
                Role = "Drums",
                BandId = 4,
                DateOfBirth = new DateTime(1971, 11, 28),
                DateOfJoining = new DateTime(1986, 6, 1)
            };
        }
    }
}
