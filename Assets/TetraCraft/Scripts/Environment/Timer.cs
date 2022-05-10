using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _standartTick;
    [SerializeField] private float _boostedTick;
    [Space]
    [SerializeField] private float _animationDelay;
    [Space]
    [SerializeField] private float _boostPerLevel;

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

    public void SpeedUp()
    {
        _standartTick -= _boostPerLevel;
    }

    private void Start()
    {
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
