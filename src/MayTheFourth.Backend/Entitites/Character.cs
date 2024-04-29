namespace MayTheFourth.Backend.Entitites;

public class Character : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Height { get; set; } = string.Empty;
    public string Weight { get; set; } = string.Empty;
    public string HairColor { get; set; } = string.Empty;
    public string SkinColor { get; set; } = string.Empty;
    public string EyeColor { get; set; } = string.Empty;
    public string BirthYear { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    
    public Planet? Planet { get; set; }
    public int? PlanetdId { get; set; }
    
    public List<Film>? Films { get; set; }
}
