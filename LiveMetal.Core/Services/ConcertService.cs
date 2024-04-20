using LiveMetal.Core.Contracts;
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

        public async Task<IEnumerable<ConcertViewModel>> GetAllConcerts()
        {
            return await _repository
                .AllReadOnly<Concert>()
                .Include(c => c.Reviews)
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
                        .OrderByDescending(r => r.ReviewId)
                        .Select(r => new ReviewViewModel
                        {
                            Content = r.Content,
                            Rating = r.Rating,
                            UserName = r.User.UserName,
                            IssuedOn = r.IssuedOn.ToString(DateFormat),
                            Title = r.Title,
                            BandName = r.Band.Name,
                            ConcertName = r.Concert.Name
                        })
                        .ToList()
                })
                .ToListAsync();
        }
    }
}
