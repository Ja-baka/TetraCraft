using System;
using UnityEngine;

public class GameCycle : IDisposable
{
    private bool _playing = true;
    private FieldEventLocator _locator;

    public GameCycle(FieldEventLocator locator)
    {
        _locator = locator;

        _locator.GameOvered += OnGameOver;
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
