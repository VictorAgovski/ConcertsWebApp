using LiveMetal.Core.Models.Band;
using LiveMetal.Core.Models.Concert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Contracts
{
    public interface IBandService
    {
        Task<IEnumerable<BandViewModel>> GetAllBands();

        Task<IEnumerable<BandAllFeaturesViewModel>> GetAllBandsWithFeatures();

        Task<IEnumerable<AllBandsViewModel>> GetAllBandsAsync();
    }
}
