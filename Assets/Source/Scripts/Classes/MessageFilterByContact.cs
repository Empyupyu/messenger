using System.Collections.Generic;
public class MessageFilterByContact : IMessageFilterStrategy
{
    private readonly CharacterID _id;
    private readonly Dictionary<CharacterID, List<MessageConfig>> _allMessages;

    public MessageFilterByContact(CharacterID id, Dictionary<CharacterID, List<MessageConfig>> allMessages)
    {
        _id = id;
        _allMessages = allMessages;
    }

    public List<MessageConfig> GetMessagesByFilter(List<MessageConfig> _visibleMessages, MessagesConfig _messagesConfig, bool isSelected)
    {
        if (!_allMessages.ContainsKey(_id)) return new List<MessageConfig>();

        _visibleMessages.Clear();

        if (isSelected)
        {
            _visibleMessages.AddRange(_allMessages[_id]);
        }
        else
        {
            _visibleMessages.AddRange(_messagesConfig.MessageConfigs);
        }

        return _visibleMessages;
    }
}
