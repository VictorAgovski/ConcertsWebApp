using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using static LiveMetal.Infrastructure.Constants.DataConstants;
using static LiveMetal.Core.Constants.MessageConstants;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LiveMetal.Core.Models.Review
{
    public class ReviewEditViewModel
    {
        public int ReviewId { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ReviewTitleMaxLength, MinimumLength = ReviewTitleMinLength, ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ReviewContentMaxLength, MinimumLength = ReviewContentMinLength, ErrorMessage = LengthMessage)]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(ReviewRatingMinValue, ReviewRatingMaxValue)]
        public int Rating { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public DateTime IssuedOn { get; set; }

        public string UserId { get; set; } = string.Empty;

        public int? ConcertId { get; set; }

        public IEnumerable<SelectListItem> Ratings { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Concerts { get; set; } = new List<SelectListItem>();
    }
}
