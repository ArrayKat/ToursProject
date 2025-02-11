using API_Tours.Models;

namespace API_Tours.Repositories
{
    public class BaseRepository
    {
        readonly protected ToursContext testContext;
        public BaseRepository(ToursContext testContext) => this.testContext = testContext;
    }
}
