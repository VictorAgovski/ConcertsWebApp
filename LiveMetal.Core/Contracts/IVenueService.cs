using LiveMetal.Core.Models.Venue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Contracts
{
    public interface IVenueService
    {
        Task<IEnumerable<VenueViewModel>> GetAllVenues();
    }
}
