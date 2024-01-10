using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MessengerPresenter : IInitializable
{
    private MessengerSystem _messengerSystem;
    private MessengerView _messengerView;
    private MessagesConfig _messagesConfig;

    private int _messagesPaddingOrigin;
    private bool _contactsIsHide;

    private Dictionary<CharacterID, MessageView> _messages = new Dictionary<CharacterID, MessageView>();

    public MessengerPresenter(MessengerSystem messengerSystem, MessengerView messengerView, MessagesConfig messagesConfig)
    {
        _messengerSystem = messengerSystem;
        _messengerView = messengerView;
        _messagesConfig = messagesConfig;

        _messagesPaddingOrigin = _messengerView.VerticalLayoutGroup.padding.top;
    }

    public void Initialize()
    {
        InitializeContacts();
    }

    private void InitializeContacts()
    {
        _messengerSystem.UpdateMessagesByIDFilterEvent += UpdateViewMessagesByIDFilterEvent;
        _messengerView.ContactHideButton.onClick.AddListener(EnableContactView);

        UpdateViewMessagesByIDFilterEvent();
    }

    private void UpdateViewMessagesByIDFilterEvent()
    {
        var messages = _messengerSystem.VisibleMessages;

        foreach (var message in messages)
        {
            var messageView = GameObject.Instantiate(_messagesConfig.MessageView, _messengerView.MessangeHolder);

            messageView.Icon.sprite = message.Icon;
            messageView.Title.text = message.Title;
            messageView.Title.color = message.TitleColor;
            messageView.Date.text = message.Date;
            messageView.Message.text = message.Message;
            messageView.Initialize(message.ID);
        }
    }

    private void EnableContactView()
    {
        _contactsIsHide = !_contactsIsHide;
        _messengerView.ContactsView.gameObject.SetActive(!_contactsIsHide);
        _messengerView.VerticalLayoutGroup.padding.top = _contactsIsHide ? 0 : _messagesPaddingOrigin;

        LayoutRebuilder.MarkLayoutForRebuild(_messengerView.MessangeHolder);
    }
}
