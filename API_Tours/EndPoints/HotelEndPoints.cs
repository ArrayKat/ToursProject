using API_Tours.Models;
using API_Tours.Servises;
using System.Data;

namespace API_Tours.EndPoints
{
    public static class HotelEndPoints
    {
        public static IEndpointRouteBuilder MapHotelEndPoints(this IEndpointRouteBuilder app)
        {
            //get all
            app.MapGet("/hotel/get_hotels", (HotelServises hotelServises) => hotelServises.GetHotels()).WithTags("Hotel");

            //add - post
            app.MapPost("/hotel/add_hotel", (HotelServises hotelServises, Hotel hotel) => hotelServises.AddHotel(hotel)).WithTags("Hotel");

            //update - put
            app.MapPut("/hotel/update_hotel", (HotelServises hotelServises, Hotel hotel) => hotelServises.UpdateHotel(hotel)).WithTags("Hotel");

            //delete
            app.MapDelete("/hotel/delete_hotel/{id}", (HotelServises hotelServises, int id) => hotelServises.DeleteHotel(id)).WithTags("Hotel");

            return app;
        }
    }
}
