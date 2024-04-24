using LiveMetal.Core.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveMetal.Infrastructure.Constants.DataConstants;
using static LiveMetal.Core.Constants.MessageConstants;
using System.ComponentModel.DataAnnotations;

namespace LiveMetal.Core.Models.Band
{
    public class BandCreateViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(BandNameMaxLength, MinimumLength = BandNameMinLength, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(BandGenreMaxLength, MinimumLength = BandGenreMinLength, ErrorMessage = LengthMessage)]
        public string Genre { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(BandBiographyMaxLength, MinimumLength = BandBiographyMinLength, ErrorMessage = LengthMessage)]
        public string Biography { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public string BandImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public DateTime FormationYear { get; set; } = DateTime.UtcNow;

        public List<BandMemberCreateViewModel> Members { get; set; } = new List<BandMemberCreateViewModel>();
    }
}
