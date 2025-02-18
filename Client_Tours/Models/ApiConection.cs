using API_Tours.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Client_Tours.Models
{
    public class ApiConection
    {
        HttpClient client = new HttpClient(); // создаем поле для обращения к клиенту

        public ApiConection()
        {
            client.BaseAddress = new Uri("http://localhost:5221/"); // настраиваем адрес для обращения к серверной части
        }

        public async Task<string> GetHotels()
        {
            HttpResponseMessage message = await client.GetAsync("hotel/get_hotels");
            string responce = await message.Content.ReadAsStringAsync();
            return responce;
        }
        public async Task PutHotels(Hotel update)
        {
            JsonContent contentUpdate = JsonContent.Create(update);
            HttpResponseMessage message = await client.PutAsync("/hotel/update_hotel", contentUpdate);
        }
        public async Task PostHotels(HotelDto add)
        {
            JsonContent contentUpdate = JsonContent.Create(add);
            HttpResponseMessage message = await client.PostAsync("/hotel/add_hotel", contentUpdate);
        }
        public async Task DeleteHotels(int idHotel)
        {
            HttpResponseMessage message = await client.DeleteAsync($"/hotel/delete_hotel/{idHotel}");
        }


        public async Task<string> GetTours() {
            HttpResponseMessage message = await client.GetAsync("tour/get_tours");
            string responce = await message.Content.ReadAsStringAsync();
            return responce;
        }
        public async Task<string> GetTourTypes()
        {
            HttpResponseMessage message = await client.GetAsync("tour_types/get_tour_types");
            string responce = await message.Content.ReadAsStringAsync();
            return responce;
        }
        public async Task<string> GetCountries()
        {
            HttpResponseMessage message = await client.GetAsync("country/get_countries");
            string responce = await message.Content.ReadAsStringAsync();
            return responce;
        }
        public async Task<string> GetTypes()
        {
            HttpResponseMessage message = await client.GetAsync("types/get_types");
            string responce = await message.Content.ReadAsStringAsync();
            return responce;
        }

        
    }
}
