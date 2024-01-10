using Supyrb;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public sealed class MessengerPresenter : IInitializable
{
    private MessengerSystem _messengerSystem;
    private MessengerView _messengerView;
    private MessagesConfig _messagesConfig;

    private bool _contactsIsHide;
    private bool _dateFilterSelected;

    private List<MessageView> _messageViews = new List<MessageView>();

    public MessengerPresenter(MessengerSystem messengerSystem, MessengerView messengerView, MessagesConfig messagesConfig)
    {
        _messengerSystem = messengerSystem;
        _messengerView = messengerView;
        _messagesConfig = messagesConfig;
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
        DisableViews();

        var messages = _messengerSystem.VisibleMessages;
        foreach (var message in messages)
        {
            var messageView = GetMessageView();

            messageView.Icon.sprite = message.Icon;
            messageView.Title.text = message.Title;
            messageView.Title.color = message.TitleColor;
            messageView.Date.text = DateTime.Parse(message.Date).ToString("d");
            messageView.Message.text = message.Message;
            messageView.Initialize(message.ID);

            messageView.DateFilterButton.onClick.RemoveAllListeners();
            messageView.DateFilterButton.onClick.AddListener(() =>
            {
                _dateFilterSelected = !_dateFilterSelected;
                Signals.Get<SelectContactSignal>().Dispatch(new MessageFilterByDate(), _dateFilterSelected);
            });

            _messageViews.Add(messageView);
        }
    }

    private void DisableViews()
    {
        foreach (var view in _messageViews) view.gameObject.SetActive(false);
    }

    private MessageView GetMessageView()
    {
        MessageView messageView = _messageViews.FirstOrDefault(m => !m.gameObject.activeSelf);

        if(!messageView)
        {
            messageView = GameObject.Instantiate(_messagesConfig.MessageView, _messengerView.MessageContetHolder);
            _messageViews.Add(messageView);
        }
        else
        {
            messageView.gameObject.SetActive(true);
        }

        return messageView;
    }

    private void EnableContactView()
    {
        _contactsIsHide = !_contactsIsHide;
        _messengerView.ContactsView.gameObject.SetActive(!_contactsIsHide);
        _messengerView.MessangeHolder.anchorMax = new Vector2(_messengerView.MessangeHolder.anchorMax.x, _contactsIsHide ? _messagesConfig.AnchorMaxForMessageHolderIfContactsIsHide :
            _messagesConfig.AnchorMaxForMessageHolderIfContactsIsVisible);

        LayoutRebuilder.MarkLayoutForRebuild(_messengerView.MessangeHolder);
    }
}
