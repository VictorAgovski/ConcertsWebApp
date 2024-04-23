using LiveMetal.Core.Models.Concert;
using LiveMetal.Infrastructure.Data.Models;
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

        Task CreateConcertAsync(ConcertCreateViewModel model, string userId);

        Task<Concert> GetConcertByIdAsync(int id);

        Task<ConcertCreateViewModel?> GetConcertFormModelByIdAsync(int id);

        Task EditConcertAsync(int id, ConcertCreateViewModel model);
    }
}
