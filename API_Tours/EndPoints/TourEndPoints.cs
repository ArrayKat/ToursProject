using API_Tours.Models;
using API_Tours.Servises;

namespace API_Tours.EndPoints
{
    public static class TourEndPoints
    {
        public static IEndpointRouteBuilder MapTourEndPoints(this IEndpointRouteBuilder app)
        {
            //get all
            app.MapGet("/tour/get_tours", (TourServises tourServises) => tourServises.GetTours()).WithTags("Tour");

            return app;
        }
    }
}
