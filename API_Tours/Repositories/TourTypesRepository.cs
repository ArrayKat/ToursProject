using API_Tours.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tours.Repositories
{
    public class TourTypesRepository : BaseRepository
    {
        public TourTypesRepository(ToursContext testContext) : base(testContext) { }

        public async Task<List<ToursType>> GetToursTypes() => await testContext.ToursTypes.ToListAsync();
    }
}
