namespace MayTheFourth.Backend.Entitites;

public class Vehicle : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public int CostInCredits { get; set; }
    public string Length { get; set; } = string.Empty;
    public string MaxSpeed { get; set; } = string.Empty;
    public int Crew { get; set; }
    public int Passengers { get; set; }
    public int CargoCapacity { get; set; }
    public string Consumables { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;

    public List<Film>? Films { get; set; }
}
