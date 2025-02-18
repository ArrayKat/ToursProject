using API_Tours.Models;
using API_Tours.Repositories;
using Newtonsoft.Json;
using System.Data;

namespace API_Tours.Servises
{
    public class HotelServises
    {
        readonly HotelRepository repository;
        public HotelServises(HotelRepository repository)
        {
            this.repository = repository;
        }

        //get all
        public async Task<IResult> GetHotels() => Results.Text(JsonConvert.SerializeObject(
        await repository.GetHotels(),
        Formatting.Indented,
        new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

        //add - post
        public async Task AddHotel(HotelDto hotel) => await repository.AddHotel(hotel);


        //update - put
        public async Task UpdateHotel(Hotel hotel) => await repository.UpdateHotel(hotel);

        //delete
        public async Task DeleteHotel(int id) => await repository.DeleteHotel(id);
    }
}
