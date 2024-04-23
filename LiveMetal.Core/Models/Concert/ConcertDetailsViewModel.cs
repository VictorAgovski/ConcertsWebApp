using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Models.Concert
{
    public class ConcertDetailsViewModel
    {
        public int ConcertId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Date { get; set; } = string.Empty;

        public string Time { get; set; } = string.Empty;

        public decimal TicketPrice { get; set; }

        public string Description { get; set; } = string.Empty;

        public string BandName { get; set; } = string.Empty;

        public string VenueName { get; set; } = string.Empty;
    }
}
