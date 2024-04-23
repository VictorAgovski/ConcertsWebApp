using LiveMetal.Core.Contracts;
using LiveMetal.Core.Exceptions;
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

        public async Task<IEnumerable<NewsViewModel>> GetAllNewsAsync()
        {
            return await _repository
                .AllReadOnly<News>()
                .OrderByDescending(n => n.PublishedOn)
                .Select(n => new NewsViewModel
                {
                    Id = n.NewsId,
                    Title = n.Title,
                    Content = n.Content,
                    PublishedOn = n.PublishedOn,
                    ImageUrl = n.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<News>> GetNewsByUserIdAsync(string id)
        {
            return await _repository
                .AllReadOnly<News>()
                .Where(x => id == x.UserId)
                .ToListAsync();
        }

        public async Task<IEnumerable<NewsViewModel>> GetTopThreeNewsAsync()
        {
            return
                await _repository
                .AllReadOnly<News>()
                .OrderByDescending(n => n.PublishedOn)
                .Take(3)
                .Select(n => new NewsViewModel
                {
                    Id = n.NewsId,
                    Title = n.Title,
                    Content = n.Content,
                    PublishedOn = n.PublishedOn,
                    ImageUrl = n.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<NewsViewModel> GetNewsByIdAsync(int id)
        {
            var newsItem = await _repository
                .AllReadOnly<News>()
                .Where(n => n.NewsId == id)
                .Select(n => new NewsViewModel
                {
                    Id = n.NewsId,
                    Title = n.Title,
                    Content = n.Content,
                    ImageUrl = n.ImageUrl,
                    PublishedOn = n.PublishedOn
                })
                .FirstOrDefaultAsync();

            if (newsItem == null)
            {
                throw new NewsNotFoundException(id);
            }

            return newsItem;
        }

        public async Task CreateNewsAsync(NewsCreateViewModel model, string userId)
        {
            var news = new News
            {
                Title = model.Title,
                Content = model.Content,
                PublishedOn = DateTime.Now,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            await _repository.AddAsync(news);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<NewsViewModel>> GetNewsViewModelByUserIdAsync(string userId)
        {
            return await _repository
                .AllReadOnly<News>()
                .Where(n => n.UserId == userId)
                .Select(n => new NewsViewModel
                {
                    Id = n.NewsId,
                    Title = n.Title,
                    Content = n.Content,
                    PublishedOn = n.PublishedOn,
                    ImageUrl = n.ImageUrl
                })
                .ToListAsync();
        }
    }
}
