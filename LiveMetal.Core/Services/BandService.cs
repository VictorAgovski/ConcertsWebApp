using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Band;
using LiveMetal.Core.Models.Concert;
using LiveMetal.Core.Models.Member;
using LiveMetal.Infrastructure.Data.Common;
using LiveMetal.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Services
{
    public class BandService : IBandService
    {
        private readonly IRepository _repository;

        public BandService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BandViewModel>> GetAllBands()
        {
            return await _repository
                .AllReadOnly<Band>()
                .Select(b => new BandViewModel
                {
                    Id = b.BandId,
                    Name = b.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<BandAllFeaturesViewModel>> GetAllBandsWithFeatures()
        {
            return await _repository
                .AllReadOnly<Band>()
                .Select(b => new BandAllFeaturesViewModel
                {
                    BandId = b.BandId,
                    Name = b.Name,
                    BandImageUrl = b.BandImageUrl,
                    Genre = b.Genre,
                    FormationYear = b.FormationYear,
                    Biography = b.Biography,
                    Members = b.BandMembers
                        .Select(m => new BandMemberViewModel
                        {
                            Id = m.MemberId,
                            Name = m.FullName,
                            Role = m.Role
                        })
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllBandsViewModel>> GetAllBandsAsync()
        {
            return await _repository
                .AllReadOnly<Band>()
                .Select(c => new AllBandsViewModel
                {
                    BandId = c.BandId,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task CreateBandAsync(BandCreateViewModel model)
        {
            var band = new Band
            {
                Name = model.Name,
                Genre = model.Genre,
                Biography = model.Biography,
                BandImageUrl = model.BandImageUrl,
                FormationYear = model.FormationYear,
                BandMembers = model.Members.Select(m => new Member
                {
                    FullName = m.FullName,
                    Role = m.Role,
                    Biography = m.Biography,
                    DateOfBirth = m.DateOfBirth,
                    DateOfJoining = m.DateOfJoining
                })
                .ToList()
            };

            await _repository.AddAsync<Band>(band);
            await _repository.SaveChangesAsync();
        }

        public async Task<Band> GetBandById(int bandId) 
            => await _repository.GetByIdAsync<Band>(bandId);
    }
}
