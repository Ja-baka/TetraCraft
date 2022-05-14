using System;
using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
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
        BindingCreator();
        BindingFieldEventLocator();
        BindGameCycle();
        BindingScore();
        BindingTimer();
        BindingPlayerInput();
        BindingFieldCells();
        BindingTetramino();
        BindingSpawner();
        BindingBooster();
        BindingController();
        BindingView();
        BndingField();
    }

    private void BndingField()
    {
        Container
            .Bind<Field>()
            .AsSingle();
    }

    private void BindingFieldCells()
    {
        Container
            .Bind<FieldCells>()
            .AsSingle();
    }

    private void BindGameCycle()
    {
        Container
            .Bind<GameCycle>()
            .AsSingle();
    }

    private void BindingFieldEventLocator()
    {
        Container
            .Bind<FieldEventLocator>()
            .AsSingle();
    }

    private void BindingView()
    {
        Container
            .BindInstance(_scoreView)
            .AsSingle();
        Container
            .BindInstance(_fieldView)
            .AsSingle();
    }

    private void BindingController()
    {
        Container
            .BindInstance(_controller)
            .AsSingle();
    }

    private void BindingBooster()
    {
        Container
            .BindInstance(_booster)
            .AsSingle();
    }

    private void BindingPlayerInput()
    {
        Container
            .BindInstance(new PlayerInput())
            .AsSingle();
    }

    private void BindingCreator()
    {
        Container
            .BindInstance(_creator)
            .AsSingle();
    }
    
    private void BindingScore()
    {
        Container
            .BindInstance(_scoreSettings);

        Container
            .Bind<Score>()
            .AsSingle();
    }

    private void BindingTimer()
    {
        Container
            .BindInstance(_timerSettings);

        Container
            .Bind<Timer>()
            .AsSingle();
    }

    private void BindingSpawner()
    {
        Container
            .Bind<Spawner>()
            .AsSingle();
    }

    private void BindingTetramino()
    {
        Container
            .Bind<Tetramino>()
            .AsSingle();
    }
}