using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveMetal.Infrastructure.Constants.DataConstants;
using static LiveMetal.Core.Constants.MessageConstants;

namespace LiveMetal.Core.Models.News
{
    public class NewsCreateViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NewsTitleMaxLength, MinimumLength = NewsTitleMinLength, ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NewsContentMaxLength, MinimumLength = NewsContentMinLength, ErrorMessage = LengthMessage)]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public DateTime PublishedOn { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public string? ImageUrl { get; set; }

        public string FormattedDate => PublishedOn.ToString(DateFormat);
    }
}
