using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Models.Concert
{
    public class ConcertDeleteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string BandName { get; set; } = string.Empty;

        public string VenueName { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string CreatorId { get; set; } = string.Empty;
    }
}
