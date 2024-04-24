using LiveMetal.Core.Models.Concert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Models.Venue
{
    public class VenueAllFeaturesViewModel
    {
        public int Id { get; set; } 

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Capacity { get; set; }

        public string ContactInfo { get; set; } = string.Empty;

        public IEnumerable<ConcertViewModel> Concerts { get; set; } = new List<ConcertViewModel>();
    }
}
