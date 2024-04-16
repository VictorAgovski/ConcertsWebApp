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
        //Task<IEnumerable<News>> GetAllNewsAsync();

        Task<IEnumerable<NewsHomeViewModel>> GetTopThreeNewsAsync();
    }
}
