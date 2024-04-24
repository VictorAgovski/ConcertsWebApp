using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveMetal.Infrastructure.Constants.DataConstants;

namespace LiveMetal.Core.Models.News
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime PublishedOn { get; set; }

        public string FormattedDate => PublishedOn.ToString(DateFormat);

        public string? ImageUrl { get; set; } = string.Empty;
    }
}
