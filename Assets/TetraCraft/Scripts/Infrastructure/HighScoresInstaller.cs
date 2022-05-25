using UnityEngine;
using Zenject;

public class HighScoresInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<INicknameGetter>().To<WindowGetNickname>().FromComponentInHierarchy().AsSingle();
        Container.Bind<HighscoresTable>().AsSingle().NonLazy();
        Container.Bind<TableView>().FromComponentInHierarchy().AsSingle();
    }
}
