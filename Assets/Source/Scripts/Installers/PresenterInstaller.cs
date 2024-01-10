using Zenject;
public sealed class PresenterInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInitializable>().To<ContactsPresenter>().AsSingle();
        Container.Bind<IInitializable>().To<MessengerPresenter>().AsSingle();
    }
}
