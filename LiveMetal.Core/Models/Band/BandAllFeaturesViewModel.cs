using LiveMetal.Core.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Models.Band
{
    public class BandAllFeaturesViewModel
    {
        public int BandId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public DateTime FormationYear { get; set; }

        public string Biography { get; set; } = string.Empty;

        public string BandImageUrl { get; set; } = string.Empty;

        public ICollection<BandMemberViewModel> Members { get; set; } = new List<BandMemberViewModel>();
    }
}
