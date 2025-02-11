using API_Tours.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tours.Repositories
{
    public class TypeRepository : BaseRepository
    {
        public TypeRepository(ToursContext testContext) : base(testContext) { }

        public async Task<List<Models.Type>> GetTypes() => await testContext.Types.ToListAsync();
    }
    
}
