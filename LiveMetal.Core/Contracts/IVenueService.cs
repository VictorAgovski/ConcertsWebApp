using LiveMetal.Core.Models.Venue;
using LiveMetal.Infrastructure.Data.Models;

namespace LiveMetal.Core.Contracts
{
    public interface IVenueService
    {
        Task<IEnumerable<VenueViewModel>> GetAllVenues();

        Task<IEnumerable<VenueAllFeaturesViewModel>> GetAllVenuesWithFeatures();

        Task AddVenueAsync(VenueCreateViewModel model);

        Task DeleteVenueAsync(VenueAllFeaturesViewModel venue);
    }
}
