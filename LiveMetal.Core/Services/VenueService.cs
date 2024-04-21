using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Venue;
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
    }
}
