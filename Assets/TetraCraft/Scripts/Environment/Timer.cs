using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _tickDuration;
    [SerializeField] private float _boostedTick;
    private float _elapsedTime = 0;
    private float _standartTick;

    public event Action Tick;

    public void StartBoost()
    {
        _tickDuration = _boostedTick;
    }

    public void EndBoost()
    {
        _tickDuration = _standartTick;
    }

    private void Start()
    {
        _standartTick = _tickDuration;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _tickDuration)
        {
            _elapsedTime = 0;
            Tick?.Invoke();
        }
    }
}
