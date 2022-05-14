using System;
using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller, IInitializable
{
    [SerializeField] private FieldView _fieldView;
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private Creator _creator;
    [SerializeField] private Booster _booster;
    [SerializeField] private PlayerController _controller;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Score.Settings _scoreSettings;
    [SerializeField] private Timer.Settings _timerSettings;

    public override void InstallBindings()
    {
        BindingInstance(_creator);
        BindingType<FieldEventLocator>();
        BindingWithSettings<Score, Score.Settings>(_scoreSettings);
        BindingWithSettings<Timer, Timer.Settings>(_timerSettings);
        BindingInstance(new PlayerInput());
        BindingType<FieldCells>();
        BindingType<Tetramino>();
        BindingInstance(_booster);
        BindingInstance(_controller);
        BindingInstance(_scoreView);
        BindingInstance(_fieldView);
        BindingType<Spawner>();
        BindingType<Field>();

        BindingType<GameCycle>();
    }

    public void Initialize()
    {
        //Debug.Log("Initialize");
        //GameCycle gameCycle = Container.Resolve<GameCycle>();
        //gameCycle.StartGame();
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

    private void BindingInterface<T, TI>()
        where T : TI
    {
        Container
            .Bind<TI>()
            .To<T>()
            .AsSingle();
    }
}