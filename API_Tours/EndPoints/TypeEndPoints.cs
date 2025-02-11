using API_Tours.Servises;

namespace API_Tours.EndPoints
{
    public static class TypeEndPoints
    {
        public static IEndpointRouteBuilder MapTypesEndPoints(this IEndpointRouteBuilder app)
        {
            //get all
            app.MapGet("/types/get_types", (TypeServises typesServises) => typesServises.GetTypes()).WithTags("Types");
            return app;
        }
    }
}
