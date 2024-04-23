using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Models.Review
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public int Rating { get; set; }

        public string IssuedOn { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string? ConcertName { get; set; }

        public string UserId { get; set; } = string.Empty;
    }
}
