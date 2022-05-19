using Zenject;

public class HighScoresInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<HighscoresTable>().AsSingle().NonLazy();
        Container.Bind<TableView>().FromComponentInHierarchy().AsSingle();
    }
}
