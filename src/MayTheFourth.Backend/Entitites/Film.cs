namespace MayTheFourth.Backend.Entitites;

public class Film : Entity
{
    public string Title { get; set; } = string.Empty;
    public int Episode { get; set; }
    public string OpeningCrawl { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }

    public List<Character>? Characters { get; set; }
    public List<Planet>? Planets { get; set; }
    public List<Vehicle>? Vehicles { get; set; }
    public List<Starship>? Starships { get; set; }
}
