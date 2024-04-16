using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Models.News
{
    public class NewsViewModel
    {
        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime PublishedOn { get; set; }

        public string FormattedDate => PublishedOn.ToString("MMMM dd, yyyy");

        public string ImageUrl { get; set; } = string.Empty;
    }
}
