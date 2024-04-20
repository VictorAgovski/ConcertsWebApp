using LiveMetal.Core.Models.Review;
using LiveMetal.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Models.Concert
{
    public class ConcertViewModel
    {
        public int ConcertId { get; set; }

        public string ConcertPicture { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Date { get; set; } = string.Empty;

        public string Time { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal TicketPrice { get; set; }

        public string BandName { get; set; } = string.Empty;

        public string VenueName { get; set; } = string.Empty;

        public List<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();
    }
}
