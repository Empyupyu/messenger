using Supyrb;
using System;
using System.Collections.Generic;
using Zenject;

public class MessengerSystem : GameSystem
{
    public event Action UpdateMessagesByIDFilterEvent;
    public List<MessageConfig> VisibleMessages => _visibleMessages;

    [Inject] private MessagesConfig _messagesConfig;

    private List<MessageConfig> _visibleMessages = new List<MessageConfig>();

    public override void OnAwake()
    {
        InitializeAllMessages();

        Signals.Get<SelectContactSignal>().AddListener(ShowMessagesByFilter);
    }

    private void InitializeAllMessages()
    {
        var messages = _messagesConfig.MessageConfigs;

        foreach (var message in messages)
        {
            if (!_game.AllMessages.ContainsKey(message.ID))
            {
                _game.AllMessages.Add(message.ID, new List<MessageConfig>());
            }

            _game.AllMessages[message.ID].Add(message);
            _visibleMessages.Add(message);
        }

        UpdateMessagesByIDFilterEvent?.Invoke();
    }

    private void ShowMessagesByFilter(IMessageFilterStrategy filter, bool isSelected)
    {
        _visibleMessages = filter.GetMessagesByFilter(_visibleMessages, _messagesConfig, isSelected);

        UpdateMessagesByIDFilterEvent?.Invoke();
    }
}
