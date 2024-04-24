using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Member;
using LiveMetal.Infrastructure.Data.Common;
using LiveMetal.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveMetal.Infrastructure.Constants.DataConstants;

namespace LiveMetal.Core.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepository _repository;

        public MemberService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateMemberAsync(BandMemberCreateViewModel model)
        {
            var member = new Member
            {
                FullName = model.FullName,
                Role = model.Role,
                Biography = model.Biography,
                DateOfBirth = model.DateOfBirth,
                DateOfJoining = model.DateOfJoining,
                BandId = model.BandId
            };

            await _repository.AddAsync(member);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteMemberAsync(int memberId)
        {
            await _repository.DeleteAsync<Member>(memberId);
            await _repository.SaveChangesAsync();
        }

        public async Task<BandMemberDetailedViewModel> GetMemberDetailsById(int memberId)
        {
            return await _repository
                .AllReadOnly<Member>()
                .Where(m => m.MemberId == memberId)
                .Select(m => new BandMemberDetailedViewModel
                {
                    MemberId = m.MemberId,
                    FullName = m.FullName,
                    Role = m.Role,
                    Biography = m.Biography,
                    DateOfBirth = m.DateOfBirth.ToString(DateFormat),
                    DateOfJoining = m.DateOfJoining.ToString(DateFormat),
                    BandName = m.Band.Name
                })
                .FirstOrDefaultAsync();
        }
    }
}
