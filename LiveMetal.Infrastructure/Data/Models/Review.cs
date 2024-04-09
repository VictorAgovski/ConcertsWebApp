using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveMetal.Infrastructure.Constants.DataConstants;

namespace LiveMetal.Infrastructure.Data.Models
{
    [Comment("Review Information")]
    public class Review
    {
        [Key]
        [Comment("Review unique identifier")]
        public int ReviewId { get; set; }

        [Required]
        [MaxLength(ReviewTitleMaxLength)]
        [Comment("Review title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(ReviewContentMaxLength)]
        [Comment("Review content")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Range(ReviewRatingMinValue, ReviewRatingMaxValue)]
        [Comment("Review rating")]
        public int Rating { get; set; }

        [Required]
        [Comment("Review publication date")]
        public DateTime IssuedOn { get; set; }

        [Required]
        [Comment("User unique identifier - foreign key")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }

        [Comment("Band unique identifier - foreign key")]
        public int? BandId { get; set; }

        [ForeignKey(nameof(BandId))]
        public Band? Band { get; set; }

        [Comment("Concert unique identifier - foreign key")]
        public int? ConcertId { get; set; }

        [ForeignKey(nameof(ConcertId))]
        public Concert? Concert { get; set; }
    }
}
