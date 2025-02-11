using API_Tours.Servises;

namespace API_Tours.EndPoints
{
    public static class CountryEndPoints
    {
        public static IEndpointRouteBuilder MapCountryEndPoints(this IEndpointRouteBuilder app)
        {
            //get all
            app.MapGet("/country/get_countries", (CountryServises countryServises) => countryServises.GetCountry()).WithTags("Country");

            return app;
        }
    }
}
