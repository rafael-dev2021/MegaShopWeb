namespace Application.Dtos.ProductsDto.Technology.Games.Valuables;

public class GameSpecificationsOVDto
{
    public string Format { get; set; } = string.Empty;
    public string AudioLanguages { get; set; } = string.Empty;
    public string SubtitleLanguages { get; set; } = string.Empty;
    public string ScreenLanguages { get; set; }
    public int MaximumNumberOfOfflinePlayers { get; set; }
    public int MaximumNumberOfOnlinePlayers { get; set; }
    public int FileSize { get; set; }
    public bool ItsMultiplayer { get; set; }
    public bool ItsOnline { get; set; }
    public bool ItsOffline { get; set; }
    public bool RequiresPeripheral { get; set; }
}
