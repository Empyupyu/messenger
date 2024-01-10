using System;
using System.Collections.Generic;
using Zenject;

public class MessengerSystem : GameSystem
{
    public event Action UpdateMessagesByIDFilterEvent;
    public List<MessageConfig> VisibleMessages => _visibleMessages;

    [Inject] private MessagesConfig _messagesConfig;

    private Dictionary<CharacterID, List<MessageConfig>> _allMessages = new Dictionary<CharacterID, List<MessageConfig>>();
    private List<MessageConfig> _visibleMessages = new List<MessageConfig>();

    public override void OnAwake()
    {
        InitializeAllMessages();
    }

    private void InitializeAllMessages()
    {
        var messages = _messagesConfig.MessageConfigs;

        foreach (var message in messages)
        {
            if (!_allMessages.ContainsKey(message.ID))
            {
                _allMessages.Add(message.ID, new List<MessageConfig>());
            }

            _allMessages[message.ID].Add(message);
            _visibleMessages.Add(message);
        }

        UpdateMessagesByIDFilterEvent?.Invoke();
    }

    public void ShowMessageByIDFilter(CharacterID id)
{
        if (!_allMessages.ContainsKey(id)) return;

        _visibleMessages.Clear();

        foreach (var message in _allMessages[id])
        {
            _visibleMessages.Add(message);
        }

        UpdateMessagesByIDFilterEvent?.Invoke();
    }
}
