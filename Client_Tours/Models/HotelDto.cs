namespace API_Tours.Models;

public partial class HotelDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CountOfStars { get; set; }

    public string CountryCode { get; set; } = null!;

    public string? Description { get; set; }

}
