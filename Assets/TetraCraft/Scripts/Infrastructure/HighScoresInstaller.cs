using UnityEngine;
using Zenject;

public class HighScoresInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        NewHighscore newHighscore = Container.Resolve<NewHighscore>();
        Container.Bind<HighscoreEntry>().FromInstance(newHighscore.Entry);
        Container.Bind<HighscoresTable>().AsSingle().NonLazy();
        Container.Bind<TableView>().FromComponentInHierarchy().AsSingle();
    }
}
