using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private const float TickValue = 1;
    private float _passedTime = 0;

    public event Action Tick;

    private void Update()
    {
        _passedTime += Time.deltaTime;
        if (_passedTime > TickValue)
        {
            _passedTime = 0;
            Tick?.Invoke();
        }
    }
}
