using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveMetal.Infrastructure.Constants.DataConstants;
using static LiveMetal.Core.Constants.MessageConstants;
using System.ComponentModel.DataAnnotations;

namespace LiveMetal.Core.Models.Concert
{
    public class ConcertCreateViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ConcertNameMaxLength, MinimumLength = ConcertNameMinLength, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        public int BandId { get; set; }

        public int VenueId { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public string Date { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public string Time { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ConcertDescriptionMaxLength, MinimumLength = ConcertDescriptionMinLength, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(ConcertTicketPriceMinValue, ConcertTicketPriceMaxValue)]
        public decimal TicketPrice { get; set; }
    }
}
