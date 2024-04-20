using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Infrastructure.Constants
{
    public static class DataConstants
    {
        // ApplicationUser

        public const int UserFirstNameMaxLength = 30;
        public const int UserFirstNameMinLength = 3;

        public const int UserLastNameMaxLength = 50;
        public const int UserLastNameMinLength = 3;

        // Bands

        public const int BandNameMaxLength = 50;
        public const int BandNameMinLength = 3;

        public const int BandGenreMaxLength = 30;
        public const int BandGenreMinLength = 3;

        public const int BandBiographyMaxLength = 1000;
        public const int BandBiographyMinLength = 10;

        // Concerts

        public const int ConcertNameMaxLength = 50;
        public const int ConcertNameMinLength = 3;

        public const int ConcertDescriptionMaxLength = 1000;
        public const int ConcertDescriptionMinLength = 10;

        public const int ConcertTicketPriceMinValue = 5;
        public const int ConcertTicketPriceMaxValue = 300;

        // Venues

        public const int VenueNameMaxLength = 50;
        public const int VenueNameMinLength = 3;

        public const int VenueLocationMaxLength = 200;
        public const int VenueLocationMinLength = 10;

        public const int VenueCapacityMinValue = 50;
        public const int VenueCapacityMaxValue = 200000;

        public const int VenueContactInfoMaxLength = 200;
        public const int VenueContactInfoMinLength = 10;

        // Reviews

        public const int ReviewTitleMaxLength = 50;
        public const int ReviewTitleMinLength = 3;

        public const int ReviewContentMaxLength = 1000;
        public const int ReviewContentMinLength = 10;

        public const int ReviewRatingMinValue = 1;
        public const int ReviewRatingMaxValue = 5;

        // Members

        public const int MemberFullNameMaxLength = 100;
        public const int MemberFullNameMinLength = 10;

        public const int MemberBiographyMaxLength = 400;
        public const int MemberBiographyMinLength = 10;

        public const int MemberRoleMaxLength = 20;
        public const int MemberRoleMinLength = 3;

        // News

        public const int NewsTitleMaxLength = 100;
        public const int NewsTitleMinLength = 3;

        public const int NewsContentMaxLength = 1000;
        public const int NewsContentMinLength = 10;

        // DateAndTimeFormats

        public const string DateFormat = "dd/MM/yyyy";
        public const string TimeFormat = "HH:mm";
    }
}
