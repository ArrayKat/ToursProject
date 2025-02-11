using API_Tours.Repositories;
using Newtonsoft.Json;

namespace API_Tours.Servises
{
    public class TourServises
    {
        readonly TourRepository repository;
        public TourServises(TourRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IResult> GetTours() => Results.Text(JsonConvert.SerializeObject(
        await repository.GetTour(),
        Formatting.Indented,
        new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
    }
}
