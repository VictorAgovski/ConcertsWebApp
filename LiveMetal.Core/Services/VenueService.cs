using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Concert;
using LiveMetal.Core.Models.Venue;
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
    public class VenueService : IVenueService
    {
        private readonly IRepository _repository;
        private readonly IConcertService _concertService;
        private readonly IReviewService _reviewService;

        public VenueService(IRepository repository, IConcertService concertService, IReviewService reviewService)
        {
            _repository = repository;
            _concertService = concertService;
            _reviewService = reviewService;
        }

        public async Task AddVenueAsync(VenueCreateViewModel model)
        {
            var venue = new Venue
            {
                Name = model.Name,
                Location = model.Location,
                Capacity = model.Capacity,
                ContactInfo = model.ContactInfo
            };

            await _repository.AddAsync<Venue>(venue);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteVenueAsync(VenueAllFeaturesViewModel venue)
        {
            var venueToDelete = await _repository.All<Venue>()
               .Include(v => v.Concerts)
               .Where(b => b.VenueId == venue.Id)
               .FirstOrDefaultAsync();

            for (int i = 0; i < venueToDelete.Concerts.Count; i++)
            {
                for (int j = 0; j < venueToDelete.Concerts[i].Reviews.Count; j++)
                {
                    await _reviewService.DeleteReviewAsync(venueToDelete.Concerts[i].Reviews[j]);
                    j++;
                }

                await _concertService.DeleteReviewsAndConcertAsync(venueToDelete.Concerts[i]);
                i++;
            }

            await _repository.DeleteAsync<Venue>(venueToDelete.VenueId);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<VenueViewModel>> GetAllVenues()
        {
            return await _repository
                .AllReadOnly<Venue>()
                .Select(v => new VenueViewModel
                {
                    Id = v.VenueId,
                    Name = v.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<VenueAllFeaturesViewModel>> GetAllVenuesWithFeatures()
        {
            return await _repository
                .AllReadOnly<Venue>()
                .Select(v => new VenueAllFeaturesViewModel
                {
                    Id = v.VenueId,
                    Name = v.Name,
                    Location = v.Location,
                    Capacity = v.Capacity,
                    ContactInfo = v.ContactInfo,
                    Concerts = v.Concerts
                        .Select(c => new ConcertViewModel
                        {
                            ConcertId = c.ConcertId,
                            Date = c.Date.ToString(DateFormat),
                            Name = c.Name,
                            Time = c.Time.ToString(TimeFormat),
                            TicketPrice = c.TicketPrice,
                        })
                        .ToList()
                })
                .ToListAsync();
        }
    }
}
