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

        public VenueService(IRepository repository)
        {
            _repository = repository;
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
