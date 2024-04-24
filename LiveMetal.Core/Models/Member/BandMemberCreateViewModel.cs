using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using static LiveMetal.Infrastructure.Constants.DataConstants;
using static LiveMetal.Core.Constants.MessageConstants;
using System.Threading.Tasks;

namespace LiveMetal.Core.Models.Member
{
    public class BandMemberCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MemberFullNameMaxLength, MinimumLength = MemberFullNameMinLength, ErrorMessage = LengthMessage)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MemberRoleMaxLength, MinimumLength = MemberRoleMinLength, ErrorMessage = LengthMessage)]
        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MemberBiographyMaxLength, MinimumLength = MemberBiographyMinLength, ErrorMessage = LengthMessage)]
        public string Biography { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public DateTime DateOfJoining { get; set; }

        public int BandId { get; set; }
    }
}
