using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
