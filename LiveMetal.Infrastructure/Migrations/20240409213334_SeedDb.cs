using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveMetal.Infrastructure.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1", 0, "c5bc90a9-092d-4744-9404-526e24fa9341", "registered@mail.com", false, "Registered", "Registeredov", false, null, "registered@mail.com", "registered@mail.com", "AQAAAAEAACcQAAAAEPLw2Hb5TOk4GPnG3Y85/Up3l4i8jMNiO2DV+o9N8pv1YC7CqljIYFcTKdYn3GbUXA==", null, false, "https://www.pngkey.com/png/detail/73-730394_admin-approved-user-registration-user-registration-icon-png.png", "ca77170d-5442-4b10-84b9-dcdaf89d0862", false, "registered@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "6f0dd8bb-9567-4f8f-9828-c44649fd6e85", "guest@mail.com", false, "Guest", "Guestov", false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAECCCAFLD03D+p3XbuD2XFbVU3gKlRBSqgCmL6FBZpM/SMPuxC6I+2v308mNuCB/dKw==", null, false, "https://ohsobserver.com/wp-content/uploads/2022/12/Guest-user.png", "7ae0ebc4-bdb9-450a-8aec-06409f029cfb", false, "guest@mail.com" },
                    { "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 0, "94ef8137-086e-4a67-8d7e-07546c26ce2d", "admin@mail.com", false, "Admin", "Adminov", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEL4cZKz9WwZkEvESf4CcoUD1TNLLpdT2n932aQDBcHizX9aCLCR8MQYZKuekzefeEA==", null, false, "https://www.wpeka.com/rgh/wp-content/uploads/2014/03/Changing-the-default-admin-user-in-WordPress1-e1462965535256.jpg", "16a582da-019b-4ce5-8a6c-fc977f6ed5ea", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "BandId", "BandImageUrl", "Biography", "FormationYear", "Genre", "Name" },
                values: new object[,]
                {
                    { 1, "https://w0.peakpx.com/wallpaper/812/225/HD-wallpaper-iron-maiden-the-trooper-music-band-trooper-flag-metal-iron-maiden-logo-heavy-iron-eddie-sword-maiden.jpg", "Iron Maiden are an English heavy metal band formed in Leyton, East London, in 1975 by bassist and primary songwriter Steve Harris. The band's discography has grown to 40 albums, including 16 studio albums, 13 live albums, four EPs, and seven compilations.", new DateTime(1975, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy Metal", "Iron Maiden" },
                    { 2, "https://i.pinimg.com/originals/04/8a/f7/048af73296084481c48c99c5f70ab378.jpg", "Metallica is an American heavy metal band. The band was formed in 1981 in Los Angeles by vocalist/guitarist James Hetfield and drummer Lars Ulrich, and has been based in San Francisco for most of its career.", new DateTime(1981, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thrash Metal", "Metallica" },
                    { 3, "https://static.wikia.nocookie.net/logopedia/images/6/6f/Nileband_logo.jpg/revision/latest?cb=20160624042213", "Nile is an American death metal band from Greenville, South Carolina, formed in 1993. The band is known for its technical and complex style of death metal.", new DateTime(1993, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Death Metal", "Nile" },
                    { 4, "https://i.pinimg.com/originals/b6/30/32/b630323cff6fdfe395e5127fb73a45e3.jpg", "Darkthrone is a Norwegian black metal band. It formed in 1986 as a death metal band under the name Black Death. In 1991, the band embraced a black metal style influenced by Bathory and Celtic Frost and became one of the leading bands in the Norwegian black metal scene.", new DateTime(1986, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black Metal", "Darkthrone" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "VenueId", "Capacity", "ContactInfo", "Latitude", "Location", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, 20000, "+44 20 8463 2000", 0.0, "Peninsula Square, London SE10 0DX, United Kingdom", 0.0, "O2 Arena" },
                    { 2, 90000, "+44 20 8795 9000", 0.0, "Wembley, London HA9 0WS, United Kingdom", 0.0, "Wembley Stadium" },
                    { 3, 5200, "+44 20 7589 8212", 0.0, "Kensington Gore, London SW7 2AP, United Kingdom", 0.0, "Royal Albert Hall" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Guest Guestov", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 2, "user:fullname", "Admin Adminov", "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                    { 3, "user:fullname", "Registered Registeredov", "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" }
                });

            migrationBuilder.InsertData(
                table: "Concerts",
                columns: new[] { "ConcertId", "BandId", "Date", "Description", "Name", "TicketPrice", "Time", "VenueId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iron Maiden are coming to London as part of their Legacy of the Beast Tour. Don't miss this unique opportunity to see one of the greatest heavy metal bands of all time!", "Iron Maiden - Legacy of the Beast Tour", 50m, new DateTime(2024, 6, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Metallica are coming to London as part of their WorldWired Tour. Don't miss this unique opportunity to see one of the greatest thrash metal bands of all time!", "Metallica - WorldWired Tour", 60m, new DateTime(2024, 7, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nile are coming to London as part of their Vile Nilotic Rites Tour. Don't miss this unique opportunity to see one of the greatest death metal bands of all time!", "Nile - Vile Nilotic Rites Tour", 40m, new DateTime(2024, 8, 30, 19, 30, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "BandId", "Biography", "DateOfBirth", "DateOfJoining", "FullName", "Role" },
                values: new object[,]
                {
                    { 1, 1, "Stephen Percy Harris (born 12 March 1956) is an English musician who is the bassist, keyboardist, backing vocalist, primary songwriter and founder of heavy metal band Iron Maiden.", new DateTime(1956, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1975, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve Harris", "Bass Guitar" },
                    { 2, 1, "David Michael Murray (born 23 December 1956) is an English guitarist and songwriter best known as one of the earliest members of the British heavy metal band Iron Maiden.", new DateTime(1956, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1976, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dave Murray", "Lead Guitar" },
                    { 3, 2, "Lars Ulrich (born 26 December 1963) is a Danish musician best known as the drummer and co-founder of American heavy metal band Metallica.", new DateTime(1963, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1981, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lars Ulrich", "Drums" },
                    { 4, 3, "Karl Sanders (born 5 June 1964) is an American musician, most widely known as the founding member of the American death metal band Nile.", new DateTime(1964, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karl Sanders", "Guitar" },
                    { 5, 4, "Gylve Fenris Nagell (born 28 November 1971), better known as Fenriz, is a Norwegian musician and politician who is best known as being one half of the metal duo Darkthrone.", new DateTime(1971, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fenriz", "Drums" }
                });

            migrationBuilder.InsertData(
                table: "UsersFavourites",
                columns: new[] { "BandId", "UserId" },
                values: new object[,]
                {
                    { 1, "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" },
                    { 2, "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" },
                    { 3, "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "BandId", "ConcertId", "Content", "IssuedOn", "Rating", "Title", "UserId" },
                values: new object[] { 1, 1, 1, "This was the best concert I've ever been to! Iron Maiden were amazing!", new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Amazing concert!", "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "BandId", "ConcertId", "Content", "IssuedOn", "Rating", "Title", "UserId" },
                values: new object[] { 2, 2, 2, "Metallica were awesome! I had a great time at the concert!", new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Great show!", "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "BandId", "ConcertId", "Content", "IssuedOn", "Rating", "Title", "UserId" },
                values: new object[] { 3, 3, 3, "Nile were brutal! I loved every second of the concert!", new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Brutal performance!", "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UsersFavourites",
                keyColumns: new[] { "BandId", "UserId" },
                keyValues: new object[] { 1, "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" });

            migrationBuilder.DeleteData(
                table: "UsersFavourites",
                keyColumns: new[] { "BandId", "UserId" },
                keyValues: new object[] { 2, "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" });

            migrationBuilder.DeleteData(
                table: "UsersFavourites",
                keyColumns: new[] { "BandId", "UserId" },
                keyValues: new object[] { 3, "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b1c1d1-e1f1-1g1h-1i1j-1k1l1m1n1o1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b");

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "BandId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Concerts",
                keyColumn: "ConcertId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "BandId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "BandId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "BandId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 3);
        }
    }
}
