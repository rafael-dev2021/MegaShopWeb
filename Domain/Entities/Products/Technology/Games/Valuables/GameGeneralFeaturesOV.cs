namespace Domain.Entities.Products.Technology.Games.Valuables;

public class GameGeneralFeaturesOV
{
    public string Collection { get; protected set; } = string.Empty;
    public string Saga { get; protected set; } = string.Empty;
    public string GameTitle { get; protected set; } = string.Empty;
    public string Edition { get; protected set; } = string.Empty;
    public string Platform { get; protected set; } = string.Empty;
    public string Developers { get; protected set; } = string.Empty;
    public string Publishers { get; protected set; } = string.Empty;
    public string Genres { get; protected set; } = string.Empty;
    public char GameRating { get; protected set; }
}
