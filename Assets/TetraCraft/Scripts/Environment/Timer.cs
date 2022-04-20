using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _tickDuration = 1;
    private float _passedTime = 0;

    public event Action Tick;

    private void Update()
    {
        _passedTime += Time.deltaTime;
        if (_passedTime > _tickDuration)
        {
            _passedTime = 0;
            Tick?.Invoke();
        }
    }
}
