using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Infrastructure.Data.Models
{
    [Comment("User Favourite Bands")]
    public class UserFavourite
    {
        [Required]
        [Comment("User unique identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Band unique identifier")]
        public int BandId { get; set; }

        [ForeignKey(nameof(BandId))]
        public Band Band { get; set; } = null!;
    }
}
