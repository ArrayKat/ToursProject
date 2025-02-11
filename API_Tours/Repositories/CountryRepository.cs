using API_Tours.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tours.Repositories
{
    public class CountryRepository : BaseRepository
    {
        public CountryRepository(ToursContext testContext) : base(testContext) { }

        public async Task<List<Country>> GetCountry() => await testContext.Countries.ToListAsync();
    }
}
