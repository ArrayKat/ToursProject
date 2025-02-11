using API_Tours.Repositories;
using Newtonsoft.Json;

namespace API_Tours.Servises
{
    public class TypeServises
    {
        readonly TypeRepository repository;
        public TypeServises(TypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IResult> GetTypes() => Results.Text(JsonConvert.SerializeObject(
        await repository.GetTypes(),
        Formatting.Indented,
        new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
    }
}
