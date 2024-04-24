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
        private readonly IReviewService _reviewService;
        private readonly IConcertService _concertService;

        public BandService(IRepository repository, IReviewService reviewService, IConcertService concertService)
        {
            _repository = repository;
            _reviewService = reviewService;
            _concertService = concertService;
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

        public async Task DeleteBandAsync(Band band)
        {
            var bandToDelete = await _repository.All<Band>()
               .Include(b => b.Concerts)
               .Where(b => b.BandId == band.BandId)
               .FirstOrDefaultAsync();

            for (int i = 0; i < bandToDelete.Concerts.Count; i++)
            {
                for (int j = 0; j < bandToDelete.Concerts[i].Reviews.Count; j++)
                {
                    await _reviewService.DeleteReviewAsync(bandToDelete.Concerts[i].Reviews[j]);
                    j++;
                }

                await _concertService.DeleteReviewsAndConcertAsync(bandToDelete.Concerts[i]);
                i++;
            }

            await _repository.DeleteAsync<Band>(bandToDelete.BandId);
            await _repository.SaveChangesAsync();
        }
    }
}
