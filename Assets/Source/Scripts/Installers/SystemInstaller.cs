using UnityEngine;
using Zenject;

public sealed class SystemInstaller : MonoInstaller
{
    [SerializeField] private ContactSystem _contactSystem;
    [SerializeField] private MessengerSystem _messengerSystem;

    public override void InstallBindings()
    {
        Container.Bind<ContactSystem>().FromInstance(_contactSystem).AsSingle();
        Container.Bind<MessengerSystem>().FromInstance(_messengerSystem).AsSingle();
    }
}
