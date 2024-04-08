using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveMetal.Infrastructure.Constants.DataConstants;

namespace LiveMetal.Infrastructure.Data.Models
{
    [Comment("Band Information")]
    public class Band
    {
        [Key]
        [Comment("Band unique identifier")]
        public int BandId { get; set; }

        [Required]
        [MaxLength(BandNameMaxLength)]
        [Comment("Band name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(BandGenreMaxLength)]
        [Comment("Band genre")]
        public string Genre { get; set; } = string.Empty;

        [Required]
        [Comment("Band formation year")]
        public DateTime FormationYear { get; set; }

        [Comment("Band biography")]
        public string Biography { get; set; } = string.Empty;

        [Comment("Band image URL")]
        public string BandImageUrl { get; set; } = string.Empty;

        public List<Concert> Concerts { get; set; } = new List<Concert>();

        public List<Review> Reviews { get; set; } = new List<Review>();

        public List<Member> BandMembers { get; set; } = new List<Member>();

        public List<UserFavourite> UserFavourites { get; set; } = new List<UserFavourite>();
    }
}
