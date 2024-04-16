using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.News;
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
    public class NewsService : INewsService
    {
        private readonly IRepository _repository;

        public NewsService(IRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<NewsHomeViewModel>> GetAllNewsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NewsHomeViewModel>> GetTopThreeNewsAsync()
        {
            return
                await _repository
                .AllReadOnly<News>()
                .OrderByDescending(n => n.PublishedOn)
                .Take(3)
                .Select(n => new NewsHomeViewModel
                {
                    Id = n.UserId,
                    Title = n.Title,
                    Content = n.Content,
                    PublishedOn = n.PublishedOn,
                    ImageUrl = n.ImageUrl
                })
                .ToListAsync();
        }
    }
}
