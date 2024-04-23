using static LiveMetal.Infrastructure.Constants.DataConstants;
using static LiveMetal.Core.Constants.MessageConstants;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LiveMetal.Core.Models.Review
{
    public class ReviewCreateViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ReviewTitleMaxLength, MinimumLength = ReviewTitleMinLength, ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ReviewContentMaxLength, MinimumLength = ReviewContentMinLength, ErrorMessage = LengthMessage)]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(ReviewRatingMinValue, ReviewRatingMaxValue)]
        public int Rating { get; set; }

        public int? ConcertId { get; set; }

        public int? BandId { get; set; }

        public List<SelectListItem> Concerts { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Bands { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Ratings { get; set; } = new List<SelectListItem>();
    }
}
