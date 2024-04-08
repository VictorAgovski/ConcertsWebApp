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
    [Comment("Venue Information")]
    public class Venue
    {
        [Key]
        [Comment("Venue unique identifier")]
        public int VenueId { get; set; }

        [Required]
        [MaxLength(VenueNameMaxLength)]
        [Comment("Venue name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(VenueLocationMaxLength)]
        [Comment("Venue location")]
        public string Location { get; set; } = string.Empty;

        [Comment("Venue latitude")]
        public double Latitude { get; set; }

        [Comment("Venue longitude")]
        public double Longitude { get; set; }

        [Required]
        [Range(VenueCapacityMinValue, VenueCapacityMaxValue)]
        [Comment("Venue capacity")]
        public int Capacity { get; set; }

        [MaxLength(VenueContactInfoMaxLength)]
        [Comment("Venue contact information")]
        public string ContactInfo { get; set; } = string.Empty;

        public List<Concert> Concerts { get; set; } = new List<Concert>();
    }
}
