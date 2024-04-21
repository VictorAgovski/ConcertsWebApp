using LiveMetal.Core.Models.Concert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Contracts
{
    public interface IConcertService
    {
        Task<IEnumerable<ConcertViewModel>> GetAllConcerts();

        Task<IEnumerable<ConcertViewModel>> RatedConcertsByUserId(string userId);

        Task CreateConcertAsync(ConcertViewModel model);
    }
}
