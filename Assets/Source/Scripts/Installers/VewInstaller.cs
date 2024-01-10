using UnityEngine;
using Zenject;

public sealed class VewInstaller : MonoInstaller
{
    [SerializeField] private ContactsView _contactsView;
    [SerializeField] private MessengerView _messengerView;

    public override void InstallBindings()
    {
        Container.Bind<ContactsView>().FromInstance(_contactsView).AsSingle();
        Container.Bind<MessengerView>().FromInstance(_messengerView).AsSingle();
    }
}
