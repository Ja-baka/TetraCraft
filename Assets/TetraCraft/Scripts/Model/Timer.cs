using System;
using UnityEngine;
using Zenject;

public class Timer : IDisposable, ITickable
{
    private Score _score;
    private readonly Settings _settings;
    private float _standartTick;
    private float _elapsedTime = 0;
    private float _currentTime;

    public Timer(Settings settings, Score score)
    {
        _settings = settings;
        _score = score;

        _standartTick = 1f;
        _currentTime = _standartTick;

        _score.ScoreUpdated += OnScoreUpdated;
    }

    public void Dispose()
    {
        _score.ScoreUpdated -= OnScoreUpdated;
    }

    public event Action TickEllapsed;

    public float AnimationTick => _settings.AnimationDelay;

    public void Tick()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _currentTime)
        {
            _elapsedTime = 0;
            TickEllapsed?.Invoke();
        }
    }

    public void StartBoost()
    {
        _currentTime = _settings.BoostedTick;
    }

    public void EndBoost()
    {
        _currentTime = _standartTick;
    }

    private void OnScoreUpdated()
    {
        int level = _score.Level - 1;
        _standartTick = Mathf.Pow(0.8f - level * 0.007f, level);
    }

    [Serializable]
    public class Settings
    {
        public float BoostedTick;
        public float AnimationDelay;
    }
}
