using API_Tours.Repositories;
using Newtonsoft.Json;

namespace API_Tours.Servises
{
    public class TourTypesServises
    {
        readonly TourTypesRepository repository;
        public TourTypesServises(TourTypesRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IResult> GetTourTypes() => Results.Text(JsonConvert.SerializeObject(
        await repository.GetToursTypes(),
        Formatting.Indented,
        new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
    }
}
