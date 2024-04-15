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
    [Comment("News Information")]
    public class News
    {
        [Key]
        [Comment("News unique identifier")]
        public int NewsId { get; set; }

        [Required]
        [MaxLength(NewsTitleMaxLength)]
        [Comment("News title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(NewsContentMaxLength)]
        [Comment("News content")]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("News publication date")]
        public DateTime PublishedOn { get; set; }

        [Required]
        [Comment("User unique identifier - foreign key")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }
    }
}
