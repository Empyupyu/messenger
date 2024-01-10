using UnityEngine;
using Zenject;
public sealed class ContactsPresenter : IInitializable
{
    private ContactSystem _contactSystem;
    private ContactsView _contactsView;
    private ContactsConfig _contactsConfig;

    public ContactsPresenter(ContactSystem contactSystem, ContactsView contactsView, ContactsConfig contactsConfig)
    {
        _contactSystem = contactSystem;
        _contactsView = contactsView;
        _contactsConfig = contactsConfig;
    }

    public void Initialize()
    {
        InitializeContacts();
    }

    private void InitializeContacts()
    {
        var contacts = _contactsConfig.ContactConfigs;

        foreach (var contact in contacts)
        {
            var contactView = GameObject.Instantiate(_contactsConfig.ContactView, _contactsView.ContactsHolder);

            contactView.Button.onClick.AddListener(() => _contactSystem.SelectContact(contact.ID));
            contactView.Icon.sprite = contact.Icon;
            contactView.Initialize(contact.ID);
        }
    }
}
