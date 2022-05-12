using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _boostedTick;
    [SerializeField] private float _animationDelay;
    [SerializeField] private Score _score;

    private float _standartTick;
    private float _elapsedTime = 0;
    private float _currentTime;

    public event Action Tick;

    public float AnimationTick => _animationDelay;

    public void StartBoost()
    {
        _currentTime = _boostedTick;
    }

    public void EndBoost()
    {
        _currentTime = _standartTick;
    }

    private void OnEnable()
    {
        _score.ScoreUpdated += OnScoreUpdated;
    }

    private void OnDisable()
    {
        _score.ScoreUpdated -= OnScoreUpdated;
    }

    private void OnScoreUpdated()
    {
        int level = _score.Level - 1;
        _standartTick = Mathf.Pow(0.8f - level * 0.007f, level);
    }

    private void Start()
    {
        _standartTick = 1f;
        _currentTime = _standartTick;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _currentTime)
        {
            _elapsedTime = 0;
            Tick?.Invoke();
        }
    }
}
