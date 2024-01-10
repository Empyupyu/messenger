using System.Collections.Generic;

public interface IMessageFilterStrategy
{
    public List<MessageConfig> GetMessagesByFilter(List<MessageConfig> _visibleMessages, MessagesConfig _messagesConfig, bool isSelected);
}
