using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveMetal.Infrastructure.Constants.DataConstants;

namespace LiveMetal.Infrastructure.Data.Models
{
    [Comment("Member Information")]
    public class Member
    {
        [Key]
        [Comment("Member unique identifier")]
        public int MemberId { get; set; }

        [Required]
        [MaxLength(MemberFullNameMaxLength)]
        [Comment("Member full name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(MemberBiographyMaxLength)]
        [Comment("Member biography")]
        public string Biography { get; set; } = string.Empty;

        [Comment("Member date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Comment("Member date of joining")]
        public DateTime DateOfJoining { get; set; }

        [Required]
        [MaxLength(MemberRoleMaxLength)]
        [Comment("Member role")]
        public string Role { get; set; } = string.Empty;

        [Required]
        [Comment("Band unique identifier - foreign key")]
        public int BandId { get; set; }

        [ForeignKey(nameof(BandId))]
        public Band? Band { get; set; }
    }
}
