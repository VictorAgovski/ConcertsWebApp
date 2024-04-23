using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveMetal.Infrastructure.Constants.DataConstants;
using static LiveMetal.Core.Constants.MessageConstants;
using System.ComponentModel.DataAnnotations;

namespace LiveMetal.Core.Models.Venue
{
    public class VenueCreateViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VenueNameMaxLength, MinimumLength = VenueNameMinLength, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VenueLocationMaxLength, MinimumLength = VenueLocationMinLength, ErrorMessage = LengthMessage)]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(VenueCapacityMinValue, VenueCapacityMaxValue)]
        public int Capacity { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VenueContactInfoMaxLength, MinimumLength = VenueContactInfoMinLength, ErrorMessage = LengthMessage)]
        public string ContactInfo { get; set; } = string.Empty;
    }
}
