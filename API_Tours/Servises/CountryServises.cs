using API_Tours.Repositories;
using Newtonsoft.Json;

namespace API_Tours.Servises
{
    public class CountryServises
    {
        readonly CountryRepository repository;
        public CountryServises(CountryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IResult> GetCountry() => Results.Text(JsonConvert.SerializeObject(
        await repository.GetCountry(),
        Formatting.Indented,
        new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
    }
}
