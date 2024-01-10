using Zenject;

public sealed class DataInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameData>().FromNew().AsSingle();
    }
}
