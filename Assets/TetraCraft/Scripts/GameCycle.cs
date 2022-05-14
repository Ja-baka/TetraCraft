using System;
using UnityEngine;

public class GameCycle : IDisposable
{
    private bool _playing = true;
    private FieldEventLocator _locator;
    private Spawner _spawner;

    public GameCycle(FieldEventLocator locator, Spawner spawner)
    {
        _locator = locator;
        _spawner = spawner;
        _locator.GameOvered += OnGameOver;

        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("Game Started");
        _spawner.Spawn();
    }

    public bool Playing => _playing;

    public void Dispose()
    {
        _locator.GameOvered -= OnGameOver;
    }

    public void OnGameOver()
    {
        if (_playing == false)
        {
            return;
        }
        _playing = false;

        Debug.Log("Game Over");
        Application.Quit();

        Time.timeScale = 0;
    }
}
