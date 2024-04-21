using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Models.Member
{
    public class BandMemberDetailedViewModel
    {
        public string FullName { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public string Biography { get; set; } = string.Empty;

        public string DateOfBirth { get; set; } = string.Empty;

        public string DateOfJoining { get; set; } = string.Empty;

        public string BandName { get; set; } = string.Empty;
    }
}
