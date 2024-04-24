using LiveMetal.Core.Models.News;
using LiveMetal.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMetal.Core.Contracts
{
    public interface INewsService
    {
        Task<IEnumerable<NewsViewModel>> GetAllNewsAsync();

        Task<IEnumerable<NewsViewModel>> GetTopThreeNewsAsync();

        Task<IEnumerable<News>> GetNewsByUserIdAsync(string id);

        Task<NewsViewModel> GetNewsByIdAsync(int id);

        Task CreateNewsAsync(NewsCreateViewModel model, string userId);

        Task<IEnumerable<NewsViewModel>> GetNewsViewModelByUserIdAsync(string userId);
    }
}
