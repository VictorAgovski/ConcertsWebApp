using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Models.Review
{
    public class ReviewDeleteViewModel
    {
        public int ReviewId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public int Rating { get; set; }

        public DateTime IssuedOn { get; set; }

        public string UserId { get; set; } = string.Empty;

        public int? ConcertId { get; set; }

        public string ConcertName { get; set;} = string.Empty;
    }
}
