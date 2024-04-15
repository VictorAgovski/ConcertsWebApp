using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveMetal.Infrastructure.Constants.DataConstants;

namespace LiveMetal.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;

        [PersonalData]
        public string ProfilePictureUrl { get; set; } = string.Empty;

        public List<Review> Reviews { get; set; } = new List<Review>();

        public List<UserFavourite> UserFavourites { get; set; } = new List<UserFavourite>();

        public List<News> NewsByUser { get; set; } = new List<News>();
    }
}
