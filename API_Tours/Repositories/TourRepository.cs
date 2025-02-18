using API_Tours.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tours.Repositories
{
    public class TourRepository : BaseRepository
    {
        public TourRepository(ToursContext testContext) : base(testContext) { }
        public async Task<List<Tour>> GetTour() => await testContext.Tours.Include(x =>x.ToursTypes).ToListAsync();
    }
}
