using System.Collections.Generic;

public sealed class GameData
{
    public Dictionary<CharacterID, List<MessageConfig>> AllMessages = new Dictionary<CharacterID, List<MessageConfig>>();
}
