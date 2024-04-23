using LiveMetal.Core.Models.Member;
using LiveMetal.Infrastructure.Data.Models;
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

        Task CreateMemberAsync(BandMemberCreateViewModel model);

        Task DeleteMemberAsync(int memberId);
    }
}
