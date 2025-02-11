using API_Tours.Models;
using API_Tours.Servises;

namespace API_Tours.EndPoints
{
    public static class TourTypesEndPoints
    {
        public static IEndpointRouteBuilder MapTourTypesEndPoints(this IEndpointRouteBuilder app)
        {
            //get all
            app.MapGet("/tour_types/get_tour_types", (TourTypesServises tourTypesServises) => tourTypesServises.GetTourTypes()).WithTags("TourTypes");

            return app;
        }
    }
}
