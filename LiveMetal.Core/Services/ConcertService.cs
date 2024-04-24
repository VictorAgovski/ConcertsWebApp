using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Band;
using LiveMetal.Core.Models.Concert;
using LiveMetal.Core.Models.News;
using LiveMetal.Core.Models.Review;
using LiveMetal.Infrastructure.Data.Common;
using LiveMetal.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiveMetal.Infrastructure.Constants.DataConstants;

namespace LiveMetal.Core.Services
{
    public class ConcertService : IConcertService
    {
        private readonly IRepository _repository;

        public ConcertService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateConcertAsync(ConcertCreateViewModel model, string userId)
        {
            var concert = new Concert
            {
                BandId = (int)model.BandId,
                Date = DateTime.Parse(model.Date),
                Time = DateTime.Parse(model.Time),
                Description = model.Description,
                Name = model.Name,
                CreatorId = userId,
                TicketPrice = model.TicketPrice,
                VenueId = (int)model.VenueId
            };

            await _repository.AddAsync(concert);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteReviewsAndConcertAsync(Concert concert)
        {
            var concertToDelete = await _repository.All<Concert>()
                .Include(g => g.Reviews)
                .Where(g => g.ConcertId == concert.ConcertId)
                .FirstOrDefaultAsync();

            foreach (var review in concertToDelete.Reviews)
            {
                await _repository.DeleteAsync<Review>(review.ReviewId);
            }

            await _repository.DeleteAsync<Concert>(concertToDelete.ConcertId);
            await _repository.SaveChangesAsync();
        }

        public async Task EditConcertAsync(int id, ConcertCreateViewModel model)
        {
            var concert = await _repository.GetByIdAsync<Concert>(id);

            if (concert != null)
            {
                concert.BandId = (int)model.BandId;
                concert.Date = DateTime.Parse(model.Date);
                concert.Time = DateTime.Parse(model.Time);
                concert.Description = model.Description;
                concert.Name = model.Name;
                concert.TicketPrice = model.TicketPrice;
                concert.VenueId = (int)model.VenueId;

                await _repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ConcertViewModel>> GetAllConcerts()
        {
            return await _repository
                .AllReadOnly<Concert>()
                .Include(c => c.Reviews)
                .OrderBy(n => n.Date)
                .Select(c => new ConcertViewModel
                {
                    ConcertId = c.ConcertId,
                    BandName = c.Band.Name,
                    Date = c.Date.ToString(DateFormat),
                    Time = c.Time.ToString(TimeFormat),
                    Description = c.Description,
                    Name = c.Name,
                    CreatorId = c.CreatorId,
                    TicketPrice = c.TicketPrice,
                    ConcertPicture = c.Band.BandImageUrl,
                    VenueName = c.Venue.Name,
                    Reviews = c.Reviews
                        .OrderByDescending(r => r.ReviewId)
                        .Select(r => new ReviewViewModel
                        {
                            Content = r.Content,
                            Rating = r.Rating,
                            UserName = $"{r.User.FirstName} {r.User.LastName}",
                            IssuedOn = r.IssuedOn.ToString(DateFormat),
                            Title = r.Title,
                            ConcertName = r.Concert.Name
                        })
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllConcertsViewModel>> GetAllConcertsAsync()
        {
            return await _repository
                .AllReadOnly<Concert>()
                .Select(b => new AllConcertsViewModel
                {
                    ConcertId = b.ConcertId,
                    Name = b.Name
                })
                .ToListAsync();
        }

        public async Task<Concert> GetConcertByIdAsync(int id)
            => await _repository.All<Concert>().Where(c => c.ConcertId == id).FirstOrDefaultAsync();

        public async Task<ConcertDeleteViewModel?> GetConcertDeleteModelByIdAsync(int id)
        {
            return await _repository
                .AllReadOnly<Concert>()
                .Include(c => c.Reviews)
                .Where(c => c.ConcertId == id)
                .Select(c => new ConcertDeleteViewModel
                {
                    Name = c.Name,
                    Date = c.Date,
                    VenueName = c.Venue.Name,
                    BandName = c.Band.Name,
                    CreatorId = c.CreatorId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ConcertDetailsViewModel?> GetConcertDetailsModelByIdAsync(int id)
        {
            return await _repository
                .AllReadOnly<Concert>()
                .Where(c => c.ConcertId == id)
                .Select(c => new ConcertDetailsViewModel
                {
                    ConcertId = c.ConcertId,
                    BandName = c.Band.Name,
                    Date = c.Date.ToString(DateFormat),
                    Time = c.Time.ToString(TimeFormat),
                    Description = c.Description,
                    Name = c.Name,
                    TicketPrice = c.TicketPrice,
                    VenueName = c.Venue.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ConcertCreateViewModel?> GetConcertFormModelByIdAsync(int id)
        {
            return await _repository
                .AllReadOnly<Concert>()
                .Where(c => c.ConcertId == id)
                .Select(c => new ConcertCreateViewModel
                {
                    BandId = c.BandId,
                    VenueId = c.VenueId,
                    Date = c.Date.ToString("yyyy-MM-dd"),
                    Time = c.Time.ToString(TimeFormat),
                    Description = c.Description,
                    Name = c.Name,
                    TicketPrice = c.TicketPrice
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ConcertViewModel>> RatedConcertsByUserId(string userId)
        {
            return await _repository
                .AllReadOnly<Concert>()
                .Include(c => c.Reviews)
                .Where(c => c.Reviews.Any(r => r.UserId == userId))
                .OrderByDescending(n => n.Date)
                .Select(c => new ConcertViewModel
                {
                    ConcertId = c.ConcertId,
                    BandName = c.Band.Name,
                    Date = c.Date.ToString(DateFormat),
                    Time = c.Time.ToString(TimeFormat),
                    Description = c.Description,
                    Name = c.Name,
                    TicketPrice = c.TicketPrice,
                    ConcertPicture = c.Band.BandImageUrl,
                    VenueName = c.Venue.Name,
                    Reviews = c.Reviews
                        .Where(r => r.UserId == userId)
                        .OrderByDescending(r => r.ReviewId)
                        .Select(r => new ReviewViewModel
                        {
                            Content = r.Content,
                            Rating = r.Rating,
                            UserName = r.User.UserName,
                            IssuedOn = r.IssuedOn.ToString(DateFormat),
                            Title = r.Title,
                            ConcertName = r.Concert.Name
                        })
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ConcertViewModel>> SearchConcertsAsync(string searchTerm)
        {
            searchTerm = searchTerm?.Trim().ToLower();
            return await _repository
                .AllReadOnly<Concert>()
                .Include(c => c.Band)
                .Include(c => c.Venue)
                .Where(c => c.Name.ToLower().Contains(searchTerm) ||
                            c.Description.ToLower().Contains(searchTerm) ||
                            c.Band.Name.ToLower().Contains(searchTerm) ||
                            c.Venue.Name.ToLower().Contains(searchTerm))
                .OrderBy(c => c.Date)
                .Select(c => new ConcertViewModel
                {
                    ConcertId = c.ConcertId,
                    Name = c.Name,
                    Date = c.Date.ToString("yyyy-MM-dd"),
                    Time = c.Time.ToString("HH:mm"),
                    Description = c.Description,
                    TicketPrice = c.TicketPrice,
                    ConcertPicture = c.Band.BandImageUrl,
                    VenueName = c.Venue.Name,
                    BandName = c.Band.Name,
                    Reviews = c.Reviews.Select(r => new ReviewViewModel
                    {
                        Content = r.Content,
                        Rating = r.Rating,
                        UserName = $"{r.User.FirstName} {r.User.LastName}",
                        IssuedOn = r.IssuedOn.ToString("yyyy-MM-dd"),
                        Title = r.Title,
                        ConcertName = r.Concert.Name
                    }).ToList()
                })
                .ToListAsync();
        }
    }
}
