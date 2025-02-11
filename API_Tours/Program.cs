using API_Tours.EndPoints;
using API_Tours.Models;
using API_Tours.Repositories;
using API_Tours.Servises;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToursContext>();

builder.Services.AddScoped<CountryRepository>();
builder.Services.AddScoped<HotelRepository>(); 
builder.Services.AddScoped<TourRepository>();
builder.Services.AddScoped<TourTypesRepository>();
builder.Services.AddScoped<TypeRepository>();

builder.Services.AddScoped<CountryServises>();
builder.Services.AddScoped<HotelServises>();
builder.Services.AddScoped<TourServises>();
builder.Services.AddScoped<TourTypesServises>();
builder.Services.AddScoped<TypeServises>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" }));


var app = builder.Build();

app.MapCountryEndPoints();
app.MapHotelEndPoints();
app.MapTourEndPoints();
app.MapTourTypesEndPoints();
app.MapTypesEndPoints();


app.UseSwagger();
app.UseSwaggerUI();

app.Run();
