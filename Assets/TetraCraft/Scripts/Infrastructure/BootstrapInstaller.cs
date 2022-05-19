using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<NewHighscore>()
            .AsSingle()
            .NonLazy();
    }
}

