using LiveMetal.Core.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Contracts
{
    public interface IMemberService
    {
        Task<BandMemberDetailedViewModel> GetMemberDetailsById(int memberId);
    }
}
