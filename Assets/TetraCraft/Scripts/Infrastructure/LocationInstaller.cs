using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private Score.Settings _scoreSettings;
    [SerializeField] private Timer.Settings _timerSettings;

    public override void InstallBindings()
    {
        BindingComponentInHierarchy<Creator>();
        BindingType<FieldEventLocator>();
        BindingWithSettings<Score, Score.Settings>(_scoreSettings);
        BindingWithSettings<Timer, Timer.Settings>(_timerSettings);
        BindingInstance(new PlayerInput());
        BindingType<FieldCells>();
        BindingType<Tetramino>();
        BindingComponentInHierarchy<Booster>();
        BindingComponentInHierarchy<PlayerController>();
        BindingComponentInHierarchy<ScoreView>();
        BindingComponentInHierarchy<FieldView>();
        BindingType<Spawner>();
        BindingType<Field>();

        BindingType<GameCycle>();
    }

    private void BindingType<T>()
    {
        Container
            .BindInterfacesAndSelfTo<T>()
            .AsSingle()
            .NonLazy();
    }

    private void BindingInstance<T>(T instance)
    {
        Container
            .BindInstance(instance)
            .AsSingle()
            .NonLazy();
    }

    private void BindingWithSettings<T, TS>(TS settings)
    {
        BindingInstance(settings);
        BindingType<T>();
    }

    private void BindingComponentInHierarchy<T>()
    {
        Container
            .Bind<T>()
            .FromComponentInHierarchy()
            .AsSingle();
    }
}