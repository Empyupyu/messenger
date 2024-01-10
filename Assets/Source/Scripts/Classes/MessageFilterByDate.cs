using System;
using System.Collections.Generic;

public class MessageFilterByDate : IMessageFilterStrategy
{
    public List<MessageConfig> GetMessagesByFilter(List<MessageConfig> _visibleMessages, MessagesConfig _messagesConfig, bool isSelected)
    {
        _visibleMessages.Clear();
        foreach (var message in _messagesConfig.MessageConfigs)
        {
            string dateTimeString = message.Date;
            var date = DateTime.Parse(dateTimeString);

            if (isSelected)
            {
                if (date > DateTime.Now) _visibleMessages.Add(message);

                continue;
            }

            _visibleMessages.AddRange(_messagesConfig.MessageConfigs);
            break;
        }

        return _visibleMessages;
    }
}
