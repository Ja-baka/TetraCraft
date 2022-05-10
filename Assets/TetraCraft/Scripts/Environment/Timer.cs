using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _standartTickDuration;
    [SerializeField] private float _boostedTickDuration;
    [Space]
    [SerializeField] private float _animationDelay;

    private float _elapsedTime = 0;
    private float _currentTime;

    public event Action Tick;

    public float AnimationTick => _animationDelay;

    public void StartBoost()
    {
        _currentTime = _boostedTickDuration;
    }

    public void EndBoost()
    {
        _currentTime = _standartTickDuration;
    }

    private void Start()
    {
        _currentTime = _standartTickDuration;
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
