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
    [Comment("Concert Information")]
    public class Concert
    {
        [Key]
        [Comment("Concert unique identifier")]
        public int ConcertId { get; set; }

        [Required]
        [MaxLength(ConcertNameMaxLength)]
        [Comment("Concert name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Concert date")]
        public DateTime Date { get; set; }

        [Required]
        [Comment("Concert time")]
        public DateTime Time { get; set; }

        [Required]
        [MaxLength(ConcertDescriptionMaxLength)]
        [Comment("Concert description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(ConcertTicketPriceMinValue, ConcertTicketPriceMaxValue)]
        [Precision(18, 2)]
        [Comment("Concert ticket price")]
        public decimal TicketPrice { get; set; }

        [Required]
        [Comment("Band unique identifier - foreign key")]
        public int BandId { get; set; }

        [ForeignKey(nameof(BandId))]
        public Band? Band { get; set; }

        [Required]
        [Comment("Venue unique identifier - foreign key")]
        public int VenueId { get; set; }

        [ForeignKey(nameof(VenueId))]
        public Venue? Venue { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
