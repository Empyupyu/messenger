using UnityEngine;
using Zenject;
public sealed class ConfigInstaller : MonoInstaller
{
    [SerializeField] private ContactsConfig _contactsConfig;
    [SerializeField] private MessagesConfig _messagesConfig;

    public override void InstallBindings()
    {
        Container.Bind<ContactsConfig>().FromInstance(_contactsConfig).AsSingle();
        Container.Bind<MessagesConfig>().FromInstance(_messagesConfig).AsSingle();
    }
}
