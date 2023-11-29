namespace Domain.Entities.Products.Technology.Games.ObjectsValue
{
    public class GameSpecificationsOV
    {
        public string Format { get; protected set; } = string.Empty;
        public string AudioLanguages { get; protected set; } = string.Empty;
        public string SubtitleLanguages { get; protected set; } = string.Empty;
        public string ScreenLanguages { get; protected set; } = string.Empty;
        public int MaximumNumberOfOfflinePlayers { get; protected set; }
        public int MaximumNumberOfOnlinePlayers { get; protected set; }
        public int FileSize { get; protected set; }
        public bool ItsMultiplayer { get; protected set; }
        public bool  ItsOnline { get; protected set; }
        public bool ItsOffline { get; protected set; }
        public bool RequiresPeripheral { get; protected set; }
    }
}
