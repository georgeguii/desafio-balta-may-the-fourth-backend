namespace MayTheFourth.Backend.Entitites
{
    public class Specie : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Classification { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public int AverageHeight { get; set; }
        public int AverageLifespan { get; set; }
        public string EyeColors { get; set; } = string.Empty;
        public string HairColors { get; set; } = string.Empty;
        public string SkinColors { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

        public Planet? Planet { get; set; }
        public int? PlanetdId { get; set; }

        public List<Character> Character { get; set; } = [];
        public List<Film> Films { get; set; } = [];
    }
}
