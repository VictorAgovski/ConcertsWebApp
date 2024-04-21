using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Band;
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
    public class BandService : IBandService
    {
        private readonly IRepository _repository;

        public BandService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BandViewModel>> GetAllBands()
        {
            return await _repository
                .AllReadOnly<Band>()
                .Select(b => new BandViewModel
                {
                    Id = b.BandId,
                    Name = b.Name
                })
                .ToListAsync();
        }
    }
}
